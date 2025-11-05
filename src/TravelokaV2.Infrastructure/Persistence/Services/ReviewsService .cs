using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.ReviewsAndRating;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Application.Services.Identity;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserReadService _users;
        public ReviewsService(IUnitOfWork uow, IMapper mapper, IUserReadService users)
        {
            _uow = uow;
            _mapper = mapper;
            _users = users;
        }
        public async Task<ReviewDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var review = await _uow.ReviewsAndRatings.GetByIdAsync(id, ct: ct)
                ?? throw new KeyNotFoundException("Review not found.");

            var dto = _mapper.Map<ReviewDto>(review);

            dto.AccomId = await _uow.AccomRRs.Query()
                .Where(ar => ar.RRId == id)
                .Select(ar => (Guid?)ar.AccomId)
                .FirstOrDefaultAsync(ct);

            if (!string.IsNullOrWhiteSpace(dto.UserId))
            {
                var map = await _users.GetUserNamesAsync(new[] { dto.UserId! }, ct);
                if (map.TryGetValue(dto.UserId!, out var name))
                    dto.UserName = name;
                else if (!string.IsNullOrWhiteSpace(dto.CreatedBy))
                    dto.UserName = dto.CreatedBy;
            }
            else if (!string.IsNullOrWhiteSpace(dto.CreatedBy))
            {
                dto.UserName = dto.CreatedBy;
            }

            return dto;
        }
        public async Task<IEnumerable<ReviewDto>> GetByAccommodationAsync(Guid accomId, CancellationToken ct)
        {
            var exists = await _uow.Accommodations.Query().AnyAsync(a => a.Id == accomId, ct);
            if (!exists) throw new KeyNotFoundException("Accommodation Not Found");

            var reviews = await _uow.AccomRRs.Query()
                .Where(x => x.AccomId == accomId)
                .Select(x => x.ReviewsAndRating!)
                .AsNoTracking()
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync(ct);

            var dtos = _mapper.Map<List<ReviewDto>>(reviews);

            foreach (var d in dtos) d.AccomId = accomId;

            var userIds = dtos.Where(d => !string.IsNullOrWhiteSpace(d.UserId))
                              .Select(d => d.UserId!)
                              .Distinct()
                              .ToList();
            if (userIds.Count > 0)
            {
                var nameMap = await _users.GetUserNamesAsync(userIds, ct);
                foreach (var d in dtos)
                {
                    if (!string.IsNullOrWhiteSpace(d.UserId) &&
                        nameMap.TryGetValue(d.UserId!, out var name))
                        d.UserName = name;
                    else if (!string.IsNullOrWhiteSpace(d.CreatedBy))
                        d.UserName = d.CreatedBy; // fallback snapshot
                }
            }

            return dtos;
        }

        public async Task<Guid> CreateAsync(Guid accomId, ReviewCreateDto dto, string currentUserId, string? currentUserName, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(currentUserId)) throw new UnauthorizedAccessException("User not authenticated.");

            var exists = await _uow.Accommodations.AnyAsync(a => a.Id == accomId, ct);
            if (!exists) throw new KeyNotFoundException("Accommodation Not Found");

            var rr = _mapper.Map<ReviewsAndRating>(dto);
            rr.CreatedAt = DateTime.UtcNow;
            rr.UserId = currentUserId;
            rr.CreatedBy = currentUserName;

            await _uow.ReviewsAndRatings.AddAsync(rr, ct);
            await _uow.SaveChangesAsync(ct);

            await _uow.AccomRRs.AddAsync(new Accom_RR
            {
                Id = Guid.NewGuid(),
                AccomId = accomId,
                RRId = rr.Id
            }, ct);

            await _uow.SaveChangesAsync(ct);
            return rr.Id;
        }

        public async Task UpdateAsync(Guid id, ReviewUpdateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var entity = await _uow.ReviewsAndRatings.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("Review not found.");

            _mapper.Map(dto, entity);
            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.ReviewsAndRatings.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("Review not found.");

            var links = await _uow.AccomRRs.Query()
                .Where(x => x.RRId == id)
                .ToListAsync(ct);

            foreach (var l in links)
                _uow.AccomRRs.Remove(l);

            _uow.ReviewsAndRatings.Remove(entity);
            await _uow.SaveChangesAsync(ct);
        }
    }
}
