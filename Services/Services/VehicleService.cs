using Microsoft.AspNetCore.Identity;
using projetNet.Models;
using projetNet.Repositories;
using projetNet.Repositories.Repositories;
using projetNet.Services.ServiceContracts;

namespace projetNet.Services.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IAuditLogRepository _auditLogRepository;
    

    public VehicleService(IVehicleRepository vehicleRepository, IAuditLogRepository auditLogRepository,  UserManager<ApplicationUser> userManager)
    {
        _vehicleRepository = vehicleRepository;
        _auditLogRepository = auditLogRepository;
        
    }

    public async Task<Vehicle?> GetByIdAsync(Guid id)
    {
        return await _vehicleRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Vehicle>> GetAllAsync()
    {
        return await _vehicleRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Vehicle>> GetByOwnerIdAsync(string ownerId)
    {
        return await _vehicleRepository.GetByOwnerIdAsync(ownerId);
    }

    public async Task<Vehicle?> GetByVinAsync(string vin)
    {
        return await _vehicleRepository.GetByVinAsync(vin);
    }

    public async Task<IEnumerable<Vehicle>> SearchAsync(string? brand, int? minYear, int? maxYear)
    {
        return await _vehicleRepository.SearchAsync(brand, minYear, maxYear);
    }

    public async Task<Vehicle> CreateAsync(Vehicle vehicle, string ownerId)
    {
        // Check if VIN already exists
        var existingVehicle = await _vehicleRepository.GetByVinAsync(vehicle.Vin);
        if (existingVehicle != null)
        {
            throw new InvalidOperationException($"Vehicle with VIN {vehicle.Vin} already exists.");
        }
        vehicle.OwnerId = ownerId;
        var result = await _vehicleRepository.AddAsync(vehicle);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = vehicle.OwnerId,
            Action = "Create Vehicle",
            EntityType = "Vehicle",
            Timestamp = DateTime.UtcNow
        });

        return result;
    }

    public async Task UpdateAsync(Vehicle vehicle)
    {
        await _vehicleRepository.UpdateAsync(vehicle);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = vehicle.OwnerId,
            Action = "Update Vehicle",
            EntityType = "Vehicle",
            Timestamp = DateTime.UtcNow
        });
    }

    public async Task DeleteAsync(Guid id)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id);
        if (vehicle == null)
        {
            throw new KeyNotFoundException($"Vehicle with ID {id} not found.");
        }

        await _vehicleRepository.DeleteAsync(id);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = vehicle.OwnerId,
            Action = "Delete Vehicle",
            EntityType = "Vehicle",
            Timestamp = DateTime.UtcNow
        });
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _vehicleRepository.ExistsAsync(id);
    }
}
