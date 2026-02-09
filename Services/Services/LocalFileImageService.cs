using projetNet.Services.ServiceContracts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace projetNet.Services.Services;

public class LocalFileImageService : IImageService
{
    private readonly string _basePath;
    private readonly string _baseUrl;
    private readonly ILogger<LocalFileImageService> _logger;

    public LocalFileImageService(IWebHostEnvironment environment, IConfiguration configuration, ILogger<LocalFileImageService> logger)
    {
        _basePath = Path.Combine(environment.WebRootPath, "uploads");
        _baseUrl = configuration["AppSettings:BaseUrl"] ?? "http://localhost:5234";
        _logger = logger;

        // Ensure base directory exists
        Directory.CreateDirectory(_basePath);
    }

    public async Task<string> UploadImageAsync(Stream file, string fileName, string folder = "vehicles")
    {
        var folderPath = Path.Combine(_basePath, folder);
        Directory.CreateDirectory(folderPath);

        var uniqueFileName = GenerateUniqueFileName(fileName);
        var filePath = Path.Combine(folderPath, uniqueFileName);

        // Optimize image before saving
        using var optimizedImage = new MemoryStream();
        await OptimizeImageAsync(file, optimizedImage);
        optimizedImage.Position = 0;

        using var fileStream = new FileStream(filePath, FileMode.Create);
        await optimizedImage.CopyToAsync(fileStream);

        var url = $"{_baseUrl}/uploads/{folder}/{uniqueFileName}";
        _logger.LogInformation("Saved image {FileName} to {FilePath}", uniqueFileName, filePath);
        return url;
    }

    public async Task<List<string>> UploadMultipleImagesAsync(IEnumerable<(Stream file, string fileName)> files, string folder = "vehicles")
    {
        var uploadTasks = files.Select(f => UploadImageAsync(f.file, f.fileName, folder));
        var results = await Task.WhenAll(uploadTasks);
        return results.ToList();
    }

    public Task<bool> DeleteImageAsync(string imageUrl)
    {
        try
        {
            var filePath = GetFilePathFromUrl(imageUrl);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                _logger.LogInformation("Deleted image {FilePath}", filePath);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete image {ImageUrl}", imageUrl);
            return Task.FromResult(false);
        }
    }

    public async Task<bool> DeleteMultipleImagesAsync(IEnumerable<string> imageUrls)
    {
        var deleteTasks = imageUrls.Select(DeleteImageAsync);
        var results = await Task.WhenAll(deleteTasks);
        return results.All(r => r);
    }

    public async Task<string> GenerateThumbnailAsync(Stream file, string fileName, int width = 300, int height = 300)
    {
        var folderPath = Path.Combine(_basePath, "thumbnails");
        Directory.CreateDirectory(folderPath);

        var uniqueFileName = $"thumb_{GenerateUniqueFileName(fileName)}";
        var filePath = Path.Combine(folderPath, uniqueFileName);

        file.Position = 0;
        using (var image = await Image.LoadAsync(file))
        {
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(width, height),
                Mode = ResizeMode.Crop
            }));

            using var fileStream = new FileStream(filePath, FileMode.Create);
            await image.SaveAsync(fileStream, new JpegEncoder { Quality = 85 });
        }

        var url = $"{_baseUrl}/uploads/thumbnails/{uniqueFileName}";
        _logger.LogInformation("Generated thumbnail {FileName}", uniqueFileName);
        return url;
    }

    private string GenerateUniqueFileName(string fileName)
    {
        var extension = Path.GetExtension(fileName);
        var uniqueName = $"{Guid.NewGuid()}{extension}";
        return uniqueName;
    }

    private string GetFilePathFromUrl(string url)
    {
        var uri = new Uri(url);
        var relativePath = uri.AbsolutePath.Replace("/uploads/", "");
        return Path.Combine(_basePath, relativePath);
    }

    private async Task OptimizeImageAsync(Stream inputStream, Stream outputStream)
    {
        inputStream.Position = 0;
        using var image = await Image.LoadAsync(inputStream);

        // Resize if too large (max 1920x1920)
        if (image.Width > 1920 || image.Height > 1920)
        {
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(1920, 1920),
                Mode = ResizeMode.Max
            }));
        }

        // Save with compression
        await image.SaveAsync(outputStream, new JpegEncoder { Quality = 85 });
    }
}
