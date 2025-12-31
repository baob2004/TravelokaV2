using Microsoft.AspNetCore.Http;
using TravelokaV2.Application.DTOs.Image;
using TravelokaV2.Application.IServices.UploadFile;
using TravelokaV2.Application.Services;

namespace TravelokaV2.Infrastructure.Persistence.Services.UploadFile
{
    public class UploadImage(IImageService imageService) : IUploadImage
    {
        private readonly IImageService _imageService = imageService;
        public async Task<ImageDto> CreateProductImagesAsync(IFormFile file, ImageCreateDto imageDto, string baseUrl, CancellationToken ct)
        {
            if (file.Length == 0)
                throw new ArgumentException("No file provided!");

            var imageModel = imageDto;
            imageModel.Url = await CreateUrlAsync(file, baseUrl);

            var id = await _imageService.CreateAsync(imageModel, ct);

            return new ImageDto
            {
                Id = id,
                Url = imageDto.Url,
                Alt = imageDto.Alt,
            };
        }

        public async Task<string> CreateUrlAsync(IFormFile file, string baseUrl)
        {
            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"{baseUrl}/images/{fileName}";
        }
    }
}
