using projetNet.Models;

namespace projetNet.Services.ServiceContracts;

public interface IVehicleService
{
    Task<Vehicle?> GetByIdAsync(Guid id);
    Task<IEnumerable<Vehicle>> GetAllAsync();
    Task<IEnumerable<Vehicle>> GetByOwnerIdAsync(string ownerId);

    Task<IEnumerable<Vehicle>> GetByStatusAsync(string status);
    Task<IEnumerable<Vehicle>> GetByStatusAndBrandAsync(string status, string brand);
    Task<Vehicle?> GetByVinAsync(string vin);
    Task<IEnumerable<Vehicle>> SearchAsync(string? brand, int? minYear, int? maxYear);
    Task<Vehicle> CreateAsync(Vehicle vehicle, string ownerId);
    Task UpdateAsync(Vehicle vehicle);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<List<string>> GetDistinctBrandsAsync();
}
