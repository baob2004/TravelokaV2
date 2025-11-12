using AutoMapper;
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
        private readonly IAccommodationRepository _accommoRepo;
        public AccommodationService(IUnitOfWork uow, IMapper mapper, IAccommodationRepository accommoRepo)
        {
            _uow = uow;
            _mapper = mapper;
            _accommoRepo = accommoRepo;
        }

        #region Accommodation
        public async Task<PagedResult<AccomSummaryDto>> GetPagedAsync(
            PagedQuery pagedQuery,
            AccomSearchRequest request,
            CancellationToken ct)
        {
            var q = await _accommoRepo.GetPagedAsync(pagedQuery, request, ct);

            var items = _mapper.Map<List<AccomSummaryDto>>(q.Items);

            return new PagedResult<AccomSummaryDto>
            {
                Items = items,
                Page = q.Page,
                PageSize = q.PageSize,
                Total = q.Total
            };
        }

        public async Task<AccomDetailDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var accom = await _accommoRepo.GetDetailsByIdAsync(id, ct);

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
                var typeExists = await _accommoRepo.AnyAsync(predicate: t => t.Id == dto.AccomTypeId.Value, ct: ct);
                if (!typeExists) throw new KeyNotFoundException("AccomType not found.");
            }

            var entity = _mapper.Map<Accommodation>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await _accommoRepo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);

            return entity.Id;
        }

        public async Task<IReadOnlyList<Guid>> CreateManyAsync(IEnumerable<AccomCreateDto> dtos, CancellationToken ct)
        {
            if (dtos is null) throw new ArgumentNullException(nameof(dtos));
            var items = dtos.ToList();
            if (items.Count == 0) return Array.Empty<Guid>();

            foreach (var d in items)
                if (string.IsNullOrWhiteSpace(d.Name))
                    throw new ArgumentException("Name is required.");

            var typeIds = items.Where(d => d.AccomTypeId.HasValue)
                               .Select(d => d.AccomTypeId!.Value)
                               .Distinct()
                               .ToList();

            if (typeIds.Count > 0)
            {
                var existIds = await _uow.AccomTypes.Query()
                    .Where(t => typeIds.Contains(t.Id))
                    .Select(t => t.Id)
                    .ToListAsync(ct);

                var missing = typeIds.Except(existIds).ToList();
                if (missing.Count > 0)
                    throw new KeyNotFoundException("One or more AccomType not found.");
            }

            var entities = items.Select(d =>
            {
                var e = _mapper.Map<Accommodation>(d);
                e.CreatedAt = DateTime.UtcNow;
                return e;
            }).ToList();

            foreach (var e in entities)
                await _uow.Accommodations.AddAsync(e, ct);

            await _uow.SaveChangesAsync(ct);

            return entities.Select(e => e.Id).ToList();
        }

        public async Task UpdateAsync(Guid id, AccomUpdateDto dto, CancellationToken ct)
        {
            var entity = await _accommoRepo.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("Accommodation Not Found");

            if (dto.AccomTypeId.HasValue)
            {
                var typeExists = await _accommoRepo.AnyAsync(predicate: t => t.AccomTypeId == dto.AccomTypeId.Value, ct: ct);
                if (!typeExists) throw new KeyNotFoundException("AccomType not found.");
            }

            _mapper.Map(dto, entity);
            entity.ModifyAt = DateTime.UtcNow;

            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _accommoRepo.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("Accommodation Not Found");

            _accommoRepo.Remove(entity);
            entity.DeletedAt = DateTime.UtcNow;

            await _uow.SaveChangesAsync(ct);
        }
        #endregion

        #region General Info
        public async Task<GeneralInfoDto?> GetGeneralInfoAsync(Guid accomId, CancellationToken ct)
        {
            var generalInfo = await _accommoRepo.GetGeneralInfoByAccomIdAsync(accomId: accomId, ct: ct);
            var res = _mapper.Map<GeneralInfoDto>(generalInfo);
            return res;
        }

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
        {
            var generalInfo = await _accommoRepo.GetPolicyByAccomIdAsync(accomId: accomId, ct: ct);
            var res = _mapper.Map<PolicyDto>(generalInfo);
            return res;
        }

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
            var accomExists = await _accommoRepo.AnyAsync(predicate: a => a.Id == accomId, ct: ct);
            if (!accomExists) throw new KeyNotFoundException("Accommodation Not Found");

            var imgExists = await _uow.Images.AnyAsync(i => i.Id == imageId, ct);
            if (!imgExists) throw new KeyNotFoundException("Image Not Found");

            var exists = await _uow.AccomImages.AnyAsync(x => x.AccomId == accomId && x.ImageId == imageId, ct);
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
            var link = await _accommoRepo.GetAccom_ImageAsync(accomId, imageId);

            if (link == null) throw new KeyNotFoundException("Image link Not Found");

            _uow.AccomImages.Remove(link);
            await _uow.SaveChangesAsync(ct);
        }

        public async Task<int> LinkImagesAsync(Guid accomId, IEnumerable<Guid> imageIds, CancellationToken ct)
        {
            if (imageIds is null) throw new ArgumentNullException(nameof(imageIds));
            var ids = imageIds.Where(x => x != Guid.Empty).Distinct().ToList();
            if (ids.Count == 0) return 0;

            var accomExists = await _uow.Accommodations.Query().AnyAsync(a => a.Id == accomId, ct);
            if (!accomExists) throw new KeyNotFoundException("Accommodation not found.");

            var existImgs = await _uow.Images.Query()
                .Where(i => ids.Contains(i.Id))
                .Select(i => i.Id)
                .ToListAsync(ct);
            var missing = ids.Except(existImgs).ToList();
            if (missing.Count > 0) throw new KeyNotFoundException("One or more images not found.");

            var already = await _uow.AccomImages.Query()
                .Where(ai => ai.AccomId == accomId && ids.Contains(ai.ImageId))
                .Select(ai => ai.ImageId)
                .ToListAsync(ct);

            var toAdd = ids.Except(already).ToList();
            foreach (var id in toAdd)
            {
                await _uow.AccomImages.AddAsync(new Accom_Image
                {
                    Id = Guid.NewGuid(),
                    AccomId = accomId,
                    ImageId = id
                }, ct);
            }

            if (toAdd.Count > 0) await _uow.SaveChangesAsync(ct);
            return toAdd.Count;
        }
        #endregion

        #region Assign Facility
        public async Task LinkFacilityAsync(Guid accomId, Guid facilityId, CancellationToken ct)
        {
            var accomExists = await _uow.Accommodations.AnyAsync(ct: ct);
            if (!accomExists) throw new KeyNotFoundException("Accommodation Not Found");

            var facExists = await _uow.Facilities.AnyAsync(ct: ct);
            if (!facExists) throw new KeyNotFoundException("Facility Not Found");

            var exists = await _uow.AccomFacilities.AnyAsync(x => x.AccomId == accomId && x.FacilityId == facilityId, ct);
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
            var link = await _accommoRepo.GetAccom_FacilityAsync(accomId, facilityId);

            if (link == null) throw new KeyNotFoundException("Facility link Not Found");

            _uow.AccomFacilities.Remove(link);
            await _uow.SaveChangesAsync(ct);
        }

        public async Task<int> LinkFacilitiesAsync(Guid accomId, IEnumerable<Guid> facilityIds, CancellationToken ct)
        {
            if (facilityIds is null) throw new ArgumentNullException(nameof(facilityIds));
            var ids = facilityIds.Where(x => x != Guid.Empty).Distinct().ToList();
            if (ids.Count == 0) return 0;

            var accomExists = await _uow.Accommodations.Query().AnyAsync(a => a.Id == accomId, ct);
            if (!accomExists) throw new KeyNotFoundException("Accommodation not found.");

            var existFacs = await _uow.Facilities.Query()
                .Where(f => ids.Contains(f.Id))
                .Select(f => f.Id)
                .ToListAsync(ct);
            var missing = ids.Except(existFacs).ToList();
            if (missing.Count > 0) throw new KeyNotFoundException("One or more facilities not found.");

            var already = await _uow.AccomFacilities.Query()
                .Where(af => af.AccomId == accomId && ids.Contains(af.FacilityId))
                .Select(af => af.FacilityId)
                .ToListAsync(ct);

            var toAdd = ids.Except(already).ToList();
            foreach (var id in toAdd)
            {
                await _uow.AccomFacilities.AddAsync(new Accom_Facility
                {
                    Id = Guid.NewGuid(),
                    AccomId = accomId,
                    FacilityId = id
                }, ct);
            }

            if (toAdd.Count > 0) await _uow.SaveChangesAsync(ct);
            return toAdd.Count;
        }
        #endregion
    }
}