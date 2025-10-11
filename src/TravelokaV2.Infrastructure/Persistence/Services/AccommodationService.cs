using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.Accommodation;
using TravelokaV2.Application.DTOs.Common;
using TravelokaV2.Application.DTOs.GeneralInfo;
using TravelokaV2.Application.DTOs.Policy;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Application.Services;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Infrastructure.Persistence.Services
{
    public class AccommodationService : IAccommodationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AccommodationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #region Accommodation
        public async Task<PagedResult<AccomSummaryDto>> GetPagedAsync(
            PagedQuery pagedQuery,
            AccomSearchRequest request,
            CancellationToken ct)
        {
            var q = _uow.Accommodations.Query(true);

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
                .ProjectTo<AccomSummaryDto>(_mapper.ConfigurationProvider)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<AccomSummaryDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                Total = total
            };
        }

        public async Task<AccomDetailDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var accom = await _uow.Accommodations.GetByIdAsync(
                id,
                asNoTracking: true,
                ct: ct,
                q => q.Include(a => a.AccomType)!,
                q => q.Include(a => a.GeneralInfo)!,
                q => q.Include(a => a.Policy)!,
                q => q.Include(a => a.Accom_Images).ThenInclude(ai => ai.Image)!,
                q => q.Include(a => a.Accom_Facilities).ThenInclude(af => af.Facility)!,
                q => q.Include(a => a.RoomCategories),
                q => q.Include(a => a.Accom_RRs).ThenInclude(ar => ar.ReviewsAndRating)!
            );

            if (accom == null) throw new KeyNotFoundException("Accommodation Not Found");

            var dto = _mapper.Map<AccomDetailDto>(accom);

            return dto;
        }

        public async Task<Guid> CreateAsync(AccomCreateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.Name)) throw new ArgumentException("Name is required.", nameof(dto.Name));

            if (dto.AccomTypeId.HasValue)
            {
                var typeExists = await _uow.AccomTypes.Query()
                    .AnyAsync(t => t.Id == dto.AccomTypeId.Value, ct);
                if (!typeExists) throw new KeyNotFoundException("AccomType not found.");
            }

            var entity = _mapper.Map<Accommodation>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await _uow.Accommodations.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);

            return entity.Id;
        }


        public async Task UpdateAsync(Guid id, AccomUpdateDto dto, CancellationToken ct)
        {
            var entity = await _uow.Accommodations.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("Accommodation Not Found");

            if (dto.AccomTypeId.HasValue)
            {
                var typeExists = await _uow.AccomTypes.Query()
                    .AnyAsync(t => t.Id == dto.AccomTypeId.Value, ct);
                if (!typeExists) throw new KeyNotFoundException("AccomType not found.");
            }

            _mapper.Map(dto, entity);
            entity.ModifyAt = DateTime.UtcNow;

            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.Accommodations.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("Accommodation Not Found");

            _uow.Accommodations.Remove(entity);
            entity.DeletedAt = DateTime.UtcNow;

            await _uow.SaveChangesAsync(ct);
        }
        #endregion

        #region General Info
        public async Task<GeneralInfoDto?> GetGeneralInfoAsync(Guid accomId, CancellationToken ct)
            => await _uow.GeneralInfos.Query().AsNoTracking()
               .Where(x => x.AccomId == accomId)
               .Select(x => _mapper.Map<GeneralInfoDto>(x))
               .FirstOrDefaultAsync(ct);

        public async Task UpsertGeneralInfoAsync(Guid accomId, GeneralInfoUpdateDto dto, CancellationToken ct)
        {
            var gi = await _uow.GeneralInfos.GetByIdAsync(accomId, ct: ct);
            if (gi == null)
            {
                gi = _mapper.Map<GeneralInfo>(dto);
                gi.AccomId = accomId;
                await _uow.GeneralInfos.AddAsync(gi, ct);
            }
            else
            {
                _mapper.Map(dto, gi);
            }
            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteGeneralInfoAsync(Guid accomId, CancellationToken ct)
        {
            var gi = await _uow.GeneralInfos.GetByIdAsync(accomId, ct: ct)
                     ?? throw new KeyNotFoundException("GeneralInfo Not Found");
            _uow.GeneralInfos.Remove(gi);
            await _uow.SaveChangesAsync(ct);
        }
        #endregion

        #region Policy
        public async Task<PolicyDto?> GetPolicyAsync(Guid accomId, CancellationToken ct)
            => await _uow.Policies.Query().AsNoTracking()
               .Where(x => x.AccomId == accomId)
               .Select(x => _mapper.Map<PolicyDto>(x))
               .FirstOrDefaultAsync(ct);

        public async Task UpsertPolicyAsync(Guid accomId, PolicyUpdateDto dto, CancellationToken ct)
        {
            var p = await _uow.Policies.GetByIdAsync(accomId, ct: ct);
            if (p == null)
            {
                p = _mapper.Map<Policy>(dto);
                p.AccomId = accomId;
                await _uow.Policies.AddAsync(p, ct);
            }
            else
            {
                _mapper.Map(dto, p);
            }
            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeletePolicyAsync(Guid accomId, CancellationToken ct)
        {
            var p = await _uow.Policies.GetByIdAsync(accomId, ct: ct)
                    ?? throw new KeyNotFoundException("Policy Not Found");
            _uow.Policies.Remove(p);
            await _uow.SaveChangesAsync(ct);
        }
        #endregion

        #region Assign Image
        public async Task LinkImageAsync(Guid accomId, Guid imageId, CancellationToken ct)
        {
            var accomExists = await _uow.Accommodations.Query().AnyAsync(a => a.Id == accomId, ct);
            if (!accomExists) throw new KeyNotFoundException("Accommodation Not Found");

            var imgExists = await _uow.Images.Query().AnyAsync(i => i.Id == imageId, ct);
            if (!imgExists) throw new KeyNotFoundException("Image Not Found");

            var exists = await _uow.AccomImages.Query()
                .AnyAsync(x => x.AccomId == accomId && x.ImageId == imageId, ct);
            if (exists) return;

            await _uow.AccomImages.AddAsync(new Accom_Image
            {
                Id = Guid.NewGuid(),
                AccomId = accomId,
                ImageId = imageId
            }, ct);

            await _uow.SaveChangesAsync(ct);
        }

        public async Task UnlinkImageAsync(Guid accomId, Guid imageId, CancellationToken ct)
        {
            var link = await _uow.AccomImages.Query()
                .FirstOrDefaultAsync(x => x.AccomId == accomId && x.ImageId == imageId, ct);

            if (link == null) throw new KeyNotFoundException("Image link Not Found");

            _uow.AccomImages.Remove(link);
            await _uow.SaveChangesAsync(ct);
        }
        #endregion

        #region Assign Facility
        public async Task LinkFacilityAsync(Guid accomId, Guid facilityId, CancellationToken ct)
        {
            var accomExists = await _uow.Accommodations.Query().AnyAsync(a => a.Id == accomId, ct);
            if (!accomExists) throw new KeyNotFoundException("Accommodation Not Found");

            var facExists = await _uow.Facilities.Query().AnyAsync(f => f.Id == facilityId, ct);
            if (!facExists) throw new KeyNotFoundException("Facility Not Found");

            var exists = await _uow.AccomFacilities.Query()
                .AnyAsync(x => x.AccomId == accomId && x.FacilityId == facilityId, ct);
            if (exists) return;

            await _uow.AccomFacilities.AddAsync(new Accom_Facility
            {
                Id = Guid.NewGuid(),
                AccomId = accomId,
                FacilityId = facilityId
            }, ct);

            await _uow.SaveChangesAsync(ct);
        }

        public async Task UnlinkFacilityAsync(Guid accomId, Guid facilityId, CancellationToken ct)
        {
            var link = await _uow.AccomFacilities.Query()
                .FirstOrDefaultAsync(x => x.AccomId == accomId && x.FacilityId == facilityId, ct);

            if (link == null) throw new KeyNotFoundException("Facility link Not Found");

            _uow.AccomFacilities.Remove(link);
            await _uow.SaveChangesAsync(ct);
        }
        #endregion
    }
}