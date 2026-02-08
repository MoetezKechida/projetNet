using projetNet.Models;

namespace projetNet.Services;

public interface IVehicleService
{
    Task<Vehicle?> GetByIdAsync(Guid id);
    Task<IEnumerable<Vehicle>> GetAllAsync();
    Task<IEnumerable<Vehicle>> GetByOwnerIdAsync(string ownerId);
    Task<Vehicle?> GetByVinAsync(string vin);
    Task<IEnumerable<Vehicle>> SearchAsync(string? brand, int? minYear, int? maxYear);
    Task<Vehicle> CreateAsync(Vehicle vehicle);
    Task UpdateAsync(Vehicle vehicle);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
