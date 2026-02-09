using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using projetNet.Services.ServiceContracts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace projetNet.Services.Services;

public class AzureBlobImageService : IImageService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly ILogger<AzureBlobImageService> _logger;
    private readonly string _baseUrl;

    public AzureBlobImageService(string connectionString, ILogger<AzureBlobImageService> logger)
    {
        _blobServiceClient = new BlobServiceClient(connectionString);
        _logger = logger;
        _baseUrl = _blobServiceClient.Uri.ToString();
    }

    public async Task<string> UploadImageAsync(Stream file, string fileName, string folder = "vehicles")
    {
        var containerClient = await GetOrCreateContainerAsync(folder);
        var blobName = GenerateUniqueBlobName(fileName);
        var blobClient = containerClient.GetBlobClient(blobName);

        // Optimize image before uploading
        using var optimizedImage = new MemoryStream();
        await OptimizeImageAsync(file, optimizedImage);
        optimizedImage.Position = 0;

        var blobHttpHeaders = new BlobHttpHeaders
        {
            ContentType = GetContentType(fileName)
        };

        await blobClient.UploadAsync(optimizedImage, new BlobUploadOptions
        {
            HttpHeaders = blobHttpHeaders
        });

        _logger.LogInformation("Uploaded image {BlobName} to container {Container}", blobName, folder);
        return blobClient.Uri.ToString();
    }

    public async Task<List<string>> UploadMultipleImagesAsync(IEnumerable<(Stream file, string fileName)> files, string folder = "vehicles")
    {
        var uploadTasks = files.Select(f => UploadImageAsync(f.file, f.fileName, folder));
        var results = await Task.WhenAll(uploadTasks);
        return results.ToList();
    }

    public async Task<bool> DeleteImageAsync(string imageUrl)
    {
        try
        {
            var (containerName, blobName) = ParseBlobUrl(imageUrl);
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            var response = await blobClient.DeleteIfExistsAsync();
            _logger.LogInformation("Deleted image {BlobName} from container {Container}", blobName, containerName);
            return response.Value;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete image {ImageUrl}", imageUrl);
            return false;
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
        var containerClient = await GetOrCreateContainerAsync("thumbnails");
        var blobName = $"thumb_{GenerateUniqueBlobName(fileName)}";
        var blobClient = containerClient.GetBlobClient(blobName);

        using var thumbnailStream = new MemoryStream();
        file.Position = 0;
        using (var image = await Image.LoadAsync(file))
        {
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(width, height),
                Mode = ResizeMode.Crop
            }));

            await image.SaveAsync(thumbnailStream, new JpegEncoder { Quality = 85 });
        }

        thumbnailStream.Position = 0;
        var blobHttpHeaders = new BlobHttpHeaders { ContentType = "image/jpeg" };

        await blobClient.UploadAsync(thumbnailStream, new BlobUploadOptions
        {
            HttpHeaders = blobHttpHeaders
        });

        _logger.LogInformation("Generated thumbnail {BlobName}", blobName);
        return blobClient.Uri.ToString();
    }

    private async Task<BlobContainerClient> GetOrCreateContainerAsync(string containerName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
        return containerClient;
    }

    private string GenerateUniqueBlobName(string fileName)
    {
        var extension = Path.GetExtension(fileName);
        var uniqueName = $"{Guid.NewGuid()}{extension}";
        return uniqueName;
    }

    private (string containerName, string blobName) ParseBlobUrl(string url)
    {
        var uri = new Uri(url);
        var segments = uri.Segments.Skip(1).ToArray(); // Skip the first empty segment
        var containerName = segments[0].TrimEnd('/');
        var blobName = string.Join("", segments.Skip(1));
        return (containerName, blobName);
    }

    private string GetContentType(string fileName)
    {
        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        return extension switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".webp" => "image/webp",
            ".bmp" => "image/bmp",
            _ => "application/octet-stream"
        };
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
