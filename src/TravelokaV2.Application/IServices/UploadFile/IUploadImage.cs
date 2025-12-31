using Microsoft.AspNetCore.Http;
using TravelokaV2.Application.DTOs.Image;

namespace TravelokaV2.Application.IServices.UploadFile
{
    public interface IUploadImage
    {
        Task<ImageDto> CreateProductImagesAsync(IFormFile file, ImageCreateDto imageCreateDto, string baseUrl, CancellationToken ct);
        Task<string> CreateUrlAsync(IFormFile file, string baseUrl);

    }
}
