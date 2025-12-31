using TravelokaV2.Application.DTOs.Image;

namespace TravelokaV2.Application.Services
{
    public interface IImageService
    {
        Task<IEnumerable<ImageDto>> GetAllAsync(CancellationToken ct);
        Task<ImageDto?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<Guid> CreateAsync(ImageCreateDto dto, CancellationToken ct);
        Task UpdateAsync(Guid id, ImageUpdateDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
        Task<IReadOnlyList<Guid>> CreateManyAsync(IEnumerable<ImageCreateDto> dtos, CancellationToken ct);

    }
}