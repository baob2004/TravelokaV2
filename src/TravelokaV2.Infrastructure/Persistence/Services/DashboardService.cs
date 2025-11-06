using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.Dashboard;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Application.Services;
using TravelokaV2.Domain.Enums;
using TravelokaV2.Infrastructure.Identity;

namespace TravelokaV2.Infrastructure.Persistence.Services
{
    public class DashboardService(IUnitOfWork uow, UserManager<AppUser> userManager) : IDashboardService
    {
        private readonly IUnitOfWork _uow = uow;
        private readonly UserManager<AppUser> _userManager = userManager;

        // ===================== INCOME =====================

        public async Task<IReadOnlyList<AccomIncomeDto>> GetIncomeAsync(IncomeQuery q, CancellationToken ct = default)
        {
            // 1) Chuẩn hoá khoảng thời gian
            (DateOnly from, DateOnly to) = NormalizeRange(q);

            // 2) Base: payment success trong khoảng (KHÔNG Include)
            var baseQ = _uow.PaymentRecords.Query()
                .Where(p => p.Status == PaymentStatus.Success)
                .Where(p => DateOnly.FromDateTime(p.CreatedAt) >= from &&
                            DateOnly.FromDateTime(p.CreatedAt) <= to);

            // 3) JOIN: PaymentRecord -> Room -> RoomCategory (lấy AccomId & Price)
            var joined =
                from pr in baseQ
                join r in _uow.Rooms.Query() on pr.RoomId equals r.Id
                join rc in _uow.RoomCategories.Query() on r.CategoryId equals rc.Id
                where rc.AccomId != null
                select new
                {
                    pr.CreatedAt,
                    Amount = r.Price ?? 0m,      // tuỳ nghiệp vụ: có thể nhân Nights/Quantity
                    AccomId = rc.AccomId!.Value
                };

            // 4) Group theo granularity
            IQueryable<TempIncomeRow> grouped;
            switch (q.Granularity)
            {
                case TimeGranularity.Day:
                    grouped = joined
                        .GroupBy(x => new { x.AccomId, D = DateOnly.FromDateTime(x.CreatedAt) })
                        .Select(g => new TempIncomeRow
                        {
                            AccomId = g.Key.AccomId,
                            Year = g.Key.D.Year,
                            Month = g.Key.D.Month,
                            Day = g.Key.D.Day,
                            Amount = g.Sum(z => z.Amount)
                        });
                    break;

                case TimeGranularity.Month:
                    grouped = joined
                        .GroupBy(x => new { x.AccomId, x.CreatedAt.Year, x.CreatedAt.Month })
                        .Select(g => new TempIncomeRow
                        {
                            AccomId = g.Key.AccomId,
                            Year = g.Key.Year,
                            Month = g.Key.Month,
                            Day = 1,
                            Amount = g.Sum(z => z.Amount)
                        });
                    break;

                default: // Year
                    grouped = joined
                        .GroupBy(x => new { x.AccomId, x.CreatedAt.Year })
                        .Select(g => new TempIncomeRow
                        {
                            AccomId = g.Key.AccomId,
                            Year = g.Key.Year,
                            Month = 1,
                            Day = 1,
                            Amount = g.Sum(z => z.Amount)
                        });
                    break;
            }

            // 5) Join lấy tên accommodation + materialize
            var rows = await (from g in grouped
                              join a in _uow.Accommodations.Query() on g.AccomId equals a.Id
                              select new
                              {
                                  g.AccomId,
                                  a.Name,
                                  g.Year,
                                  g.Month,
                                  g.Day,
                                  g.Amount
                              })
                             .OrderBy(x => x.Name)
                             .ThenBy(x => x.Year).ThenBy(x => x.Month).ThenBy(x => x.Day)
                             .ToListAsync(ct);

            // 6) Gộp về AccomIncomeDto
            var result = rows
                .GroupBy(x => new { x.AccomId, x.Name })
                .Select(g => new AccomIncomeDto
                {
                    AccomId = g.Key.AccomId,
                    AccomName = g.Key.Name,
                    Points = g.Select(x => new IncomePointDto
                    {
                        Period = new DateOnly(x.Year, x.Month, x.Day),
                        Amount = x.Amount
                    })
                                  .ToList(),
                    Total = g.Sum(x => x.Amount)
                })
                .OrderByDescending(x => x.Total)
                .ToList();

            return result;
        }

        // ===================== COUNTS =====================

        public async Task<AccomNumberDto> GetAccomNumberAsync(CancellationToken ct = default)
        {
            var count = await _uow.Accommodations.Query().CountAsync(ct);
            return new AccomNumberDto { AccomNumber = count };
        }

        public async Task<UserNumberDto> GetUserNumberAsync(CancellationToken ct = default)
        {
            var count = await _userManager.Users.CountAsync(ct);
            return new UserNumberDto { UserNumber = count };
        }

        // ===================== REVIEWS =====================

        public async Task<IReadOnlyList<AccomReviewDto>> GetReviewsAsync(ReviewQuery q, CancellationToken ct = default)
        {
            // 1) Chuẩn hoá khoảng thời gian
            (DateOnly from, DateOnly to) = NormalizeRange(q);

            // 2) Base: review chưa xoá mềm trong khoảng thời gian
            var rrQ = _uow.ReviewsAndRatings.Query()
                .Where(r => !r.IsDeleted)
                .Where(r => DateOnly.FromDateTime(r.CreatedAt) >= from &&
                            DateOnly.FromDateTime(r.CreatedAt) <= to);

            // 3) JOIN: ReviewsAndRating -> Accom_RR -> Accommodation
            var joined =
                from rr in rrQ
                join ar in _uow.AccomRRs.Query() on rr.Id equals ar.RRId
                join acc in _uow.Accommodations.Query() on ar.AccomId equals acc.Id
                select new
                {
                    rr.CreatedAt,
                    AccomId = acc.Id,
                    AccomName = acc.Name
                };

            // 4) Group theo granularity
            IQueryable<TempReviewRow> grouped;
            switch (q.Granularity)
            {
                case TimeGranularity.Month:
                    grouped = joined
                        .GroupBy(x => new { x.AccomId, x.AccomName, x.CreatedAt.Year, x.CreatedAt.Month })
                        .Select(g => new TempReviewRow
                        {
                            AccomId = g.Key.AccomId,
                            AccomName = g.Key.AccomName!,
                            Year = g.Key.Year,
                            Month = g.Key.Month,
                            Day = 1,
                            Count = g.Count()
                        });
                    break;

                case TimeGranularity.Year:
                    grouped = joined
                        .GroupBy(x => new { x.AccomId, x.AccomName, x.CreatedAt.Year })
                        .Select(g => new TempReviewRow
                        {
                            AccomId = g.Key.AccomId,
                            AccomName = g.Key.AccomName!,
                            Year = g.Key.Year,
                            Month = 1,
                            Day = 1,
                            Count = g.Count()
                        });
                    break;

                default: // Day
                    grouped = joined
                        .GroupBy(x => new { x.AccomId, x.AccomName, D = DateOnly.FromDateTime(x.CreatedAt) })
                        .Select(g => new TempReviewRow
                        {
                            AccomId = g.Key.AccomId,
                            AccomName = g.Key.AccomName!,
                            Year = g.Key.D.Year,
                            Month = g.Key.D.Month,
                            Day = g.Key.D.Day,
                            Count = g.Count()
                        });
                    break;
            }

            // 5) Materialize và gộp về DTO
            var rows = await grouped
                .OrderBy(x => x.AccomName)
                .ThenBy(x => x.Year).ThenBy(x => x.Month).ThenBy(x => x.Day)
                .ToListAsync(ct);

            var result = rows
                .GroupBy(x => new { x.AccomId, x.AccomName })
                .Select(g => new AccomReviewDto
                {
                    AccomId = g.Key.AccomId,
                    AccomName = g.Key.AccomName,
                    Points = g.Select(x => new ReviewPointDto
                    {
                        Period = new DateOnly(x.Year, x.Month, x.Day),
                        Count = x.Count
                    })
                                  .ToList(),
                    Total = g.Sum(x => x.Count)
                })
                .OrderByDescending(x => x.Total)
                .ToList();

            return result;
        }

        // ===================== Helpers =====================

        private struct TempIncomeRow
        {
            public Guid AccomId { get; set; }
            public int Year { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
            public decimal Amount { get; set; }
        }

        private struct TempReviewRow
        {
            public Guid AccomId { get; set; }
            public string AccomName { get; set; }
            public int Year { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
            public int Count { get; set; }
        }

        private static (DateOnly from, DateOnly to) NormalizeRange(IncomeQuery q)
        {
            if (q.Year.HasValue)
            {
                var y = q.Year.Value;
                return (new DateOnly(y, 1, 1), new DateOnly(y, 12, 31));
            }

            var to = q.To ?? DateOnly.FromDateTime(DateTime.UtcNow);
            var from = q.From ?? to.AddDays(-30);
            if (from > to) (from, to) = (to, from);
            return (from, to);
        }

        private static (DateOnly from, DateOnly to) NormalizeRange(ReviewQuery q)
        {
            if (q.Year.HasValue)
            {
                var y = q.Year.Value;
                return (new DateOnly(y, 1, 1), new DateOnly(y, 12, 31));
            }

            var to = q.To ?? DateOnly.FromDateTime(DateTime.UtcNow);
            var from = q.From ?? to.AddDays(-30);
            if (from > to) (from, to) = (to, from);
            return (from, to);
        }
    }
}
