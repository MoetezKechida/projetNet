namespace projetNet.Services.ServiceContracts;

public interface IImageService
{
    Task<string> UploadImageAsync(Stream file, string fileName, string folder = "vehicles");
    Task<List<string>> UploadMultipleImagesAsync(IEnumerable<(Stream file, string fileName)> files, string folder = "vehicles");
    Task<bool> DeleteImageAsync(string imageUrl);
    Task<bool> DeleteMultipleImagesAsync(IEnumerable<string> imageUrls);
    Task<string> GenerateThumbnailAsync(Stream file, string fileName, int width = 300, int height = 300);
}
