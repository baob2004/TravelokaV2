using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.Image;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ImageService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ImageDto>> GetAllAsync(CancellationToken ct)
        {
            var entities = await _uow.Images.Query()
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync(ct);

            return _mapper.Map<IEnumerable<ImageDto>>(entities);
        }

        public async Task<ImageDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.Images.GetByIdAsync(id, ct: ct)
                        ?? throw new KeyNotFoundException("Image not found.");
            return _mapper.Map<ImageDto>(entity);
        }

        public async Task<Guid> CreateAsync(ImageCreateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Url))
                throw new ArgumentException("Url is required.", nameof(dto.Url));

            var duplicate = await _uow.Images.Query()
                .AnyAsync(x => x.Url == dto.Url, ct);
            if (duplicate) throw new InvalidOperationException("Image URL already exists.");

            var entity = _mapper.Map<Image>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await _uow.Images.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, ImageUpdateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Url))
                throw new ArgumentException("Url is required.", nameof(dto.Url));

            var entity = await _uow.Images.GetByIdAsync(id, asNoTracking: false, ct: ct)
                        ?? throw new KeyNotFoundException("Image not found.");

            var duplicate = await _uow.Images.Query()
                .AnyAsync(x => x.Id != id && x.Url == dto.Url, ct);
            if (duplicate) throw new InvalidOperationException("Another image with the same URL exists.");

            _mapper.Map(dto, entity);
            entity.ModifyAt = DateTime.UtcNow;

            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.Images.GetByIdAsync(id, asNoTracking: false, ct: ct)
                        ?? throw new KeyNotFoundException("Image not found.");

            _uow.Images.Remove(entity);
            await _uow.SaveChangesAsync(ct);
        }

        public async Task<IReadOnlyList<Guid>> CreateManyAsync(IEnumerable<ImageCreateDto> dtos, CancellationToken ct)
        {
            if (dtos is null) throw new ArgumentNullException(nameof(dtos));
            var inputs = dtos.ToList();
            if (inputs.Count == 0) return Array.Empty<Guid>();

            foreach (var d in inputs)
                if (string.IsNullOrWhiteSpace(d.Url))
                    throw new ArgumentException("Url is required.", nameof(d.Url));

            var now = DateTime.UtcNow;

            var existingUrls = await _uow.Images.Query()
                .Where(i => i.Url != null)
                .Select(i => i.Url!)
                .ToListAsync(ct);

            var existingSet = new HashSet<string>(existingUrls.Select(u => u.ToLowerInvariant()));
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var toCreate = new List<Image>();

            foreach (var d in inputs)
            {
                var url = d.Url!.Trim();
                if (!seen.Add(url)) continue;
                if (existingSet.Contains(url.ToLowerInvariant())) continue;

                var entity = _mapper.Map<Image>(d);
                entity.CreatedAt = now;
                toCreate.Add(entity);
            }

            if (toCreate.Count == 0) return Array.Empty<Guid>();

            foreach (var e in toCreate)
                await _uow.Images.AddAsync(e, ct);

            await _uow.SaveChangesAsync(ct);
            return toCreate.Select(e => e.Id).ToList();
        }
    }
}
