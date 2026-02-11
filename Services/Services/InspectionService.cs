using projetNet.Models;
using projetNet.Repositories.Repositories;
using projetNet.Services.ServiceContracts;

namespace projetNet.Services.Services;

public class InspectionService : IInspectionService
{
    private readonly IInspectionRepository _inspectionRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IAuditLogRepository _auditLogRepository;
    private readonly IVehicleService _vehicleService;

    public InspectionService(
        IInspectionRepository inspectionRepository,
        IVehicleRepository vehicleRepository,
        IAuditLogRepository auditLogRepository,
        IVehicleService vehicleService)
    {
        _inspectionRepository = inspectionRepository;
        _vehicleRepository = vehicleRepository;
        _auditLogRepository = auditLogRepository;
        _vehicleService = vehicleService;
    }

    public async Task<Inspection?> GetByIdAsync(Guid id)
    {
        return await _inspectionRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Inspection>> GetAllAsync()
    {
        return await _inspectionRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Inspection>> GetByVehicleIdAsync(Guid vehicleId)
    {
        return await _inspectionRepository.GetByVehicleIdAsync(vehicleId);
    }

    public async Task<IEnumerable<Inspection>> GetByInspectorIdAsync(string inspectorId)
    {
        return await _inspectionRepository.GetByInspectorIdAsync(inspectorId);
    }
    
    public async Task<Inspection> CreateAsync(Guid vehicleId, string inspectorId, string reason)
    {
        
        var inspection = new Inspection
        {
            Id = Guid.NewGuid(),        // generate a new ID
            VehicleId = vehicleId,      // vehicle ID from controller
            InspectorId = inspectorId,  // inspector from logged-in user
            Reason = reason,            // reason from form
            
        };

       
        var result = await _inspectionRepository.AddAsync(inspection);
        
        var vehicle = await _vehicleService.GetByIdAsync(vehicleId);
        if (vehicle != null)
        {
            vehicle.Status = "declined";
            await _vehicleService.UpdateAsync(vehicle); // save status change
        }
        
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = inspectorId,
            Action = "Create Inspection",
            EntityType = "Inspection",
            Timestamp = DateTime.UtcNow
        });

        return result;
    }

    

    

    public async Task UpdateInspectionAsync(Inspection inspection)
    {
        await _inspectionRepository.UpdateAsync(inspection);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = inspection.InspectorId,
            Action = "Update Inspection",
            EntityType = "Inspection",
            Timestamp = DateTime.UtcNow
        });
    }

    

    public async Task DeleteAsync(Guid id)
    {
        var inspection = await _inspectionRepository.GetByIdAsync(id);
        if (inspection == null)
        {
            throw new KeyNotFoundException($"Inspection with ID {id} not found.");
        }

        await _inspectionRepository.DeleteAsync(id);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = inspection.InspectorId,
            Action = "Delete Inspection",
            EntityType = "Inspection",
            Timestamp = DateTime.UtcNow
        });
    }
}
