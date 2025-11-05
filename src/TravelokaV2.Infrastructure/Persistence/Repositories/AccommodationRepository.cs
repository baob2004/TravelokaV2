using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelBooking.Infrastructure.Persistence.Repositories;
using TravelokaV2.Application.DTOs.Accommodation;
using TravelokaV2.Application.DTOs.Common;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Repositories
{
    public class AccommodationRepository : GenericRepository<Accommodation>, IAccommodationRepository
    {
        public AccommodationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Accom_Facility> GetAccom_Facility(Guid accomId, Guid facilityId)
        {
            var link = await _context.AccomFacilities.AsQueryable()
                .FirstOrDefaultAsync(x => x.AccomId == accomId && x.FacilityId == facilityId);

            if (link == null) throw new KeyNotFoundException("Facility link Not Found");
            return link;
        }

        public async Task<Accom_Image> GetAccom_Image(Guid accomId, Guid imageId)
        {
            var link = await _context.AccomImages.AsQueryable()
                .FirstOrDefaultAsync(x => x.AccomId == accomId && x.ImageId == imageId);

            if (link == null) throw new KeyNotFoundException("Image link Not Found");
            return link;
        }

        public async Task<GeneralInfo> GetGeneralInfoByAccomId(Guid accomId, CancellationToken ct)
        {
            var res = await _context.GeneralInfos.AsQueryable()
              .Where(x => x.AccomId == accomId)
              .FirstOrDefaultAsync(ct);
            if (res == null) throw new KeyNotFoundException();
            return res;
        }

        public async Task<PagedResult<Accommodation>> GetPaged(PagedQuery pagedQuery, AccomSearchRequest request, CancellationToken ct)
        {
            var q = _context.Accommodations.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Q))
                q = q.Where(a =>
                    (a.Name != null && a.Name.Contains(request.Q)) ||
                    (a.Address != null && a.Address.Contains(request.Q)));

            if (request.AccomTypeId.HasValue)
                q = q.Where(a => a.AccomTypeId == request.AccomTypeId);

            if (request.StarMin.HasValue)
                q = q.Where(a => a.Star >= request.StarMin);

            if (request.RatingMin.HasValue)
                q = q.Where(a => a.Rating >= request.RatingMin);

            var total = await q.CountAsync(ct);

            var sortBy = pagedQuery.SortBy?.ToLowerInvariant();
            var desc = pagedQuery.Desc;

            q = sortBy switch
            {
                "name" => desc ? q.OrderByDescending(a => a.Name) : q.OrderBy(a => a.Name),
                "star" => desc ? q.OrderByDescending(a => a.Star) : q.OrderBy(a => a.Star),
                "createdat" => desc ? q.OrderByDescending(a => a.CreatedAt) : q.OrderBy(a => a.CreatedAt),
                "rating" => desc ? q.OrderByDescending(a => a.Rating) : q.OrderBy(a => a.Rating),
                _ => desc ? q.OrderByDescending(a => a.Rating) : q.OrderBy(a => a.Rating),
            };

            var page = pagedQuery.Page <= 0 ? 1 : pagedQuery.Page;
            var pageSize = pagedQuery.PageSize <= 0 ? 20 : pagedQuery.PageSize;

            var items = await q
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<Accommodation>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                Total = total
            };
        }

        public async Task<Policy> GetPolicyByAccomId(Guid accomId, CancellationToken ct)
        {
            var res = await _context.Policies.AsQueryable().AsNoTracking()
               .Where(x => x.AccomId == accomId)
               .FirstOrDefaultAsync(ct);
            if (res == null) throw new KeyNotFoundException();
            return res;
        }
    }
}