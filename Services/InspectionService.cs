using projetNet.Models;
using projetNet.Repositories;

namespace projetNet.Services;

public class InspectionService : IInspectionService
{
    private readonly IInspectionRepository _inspectionRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IAuditLogRepository _auditLogRepository;

    public InspectionService(
        IInspectionRepository inspectionRepository,
        IVehicleRepository vehicleRepository,
        IAuditLogRepository auditLogRepository)
    {
        _inspectionRepository = inspectionRepository;
        _vehicleRepository = vehicleRepository;
        _auditLogRepository = auditLogRepository;
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

    public async Task<IEnumerable<Inspection>> GetPendingInspectionsAsync()
    {
        return await _inspectionRepository.GetPendingInspectionsAsync();
    }

    public async Task<Inspection> ScheduleInspectionAsync(Inspection inspection)
    {
        // Validate vehicle exists
        var vehicleExists = await _vehicleRepository.ExistsAsync(inspection.VehicleId);
        if (!vehicleExists)
        {
            throw new KeyNotFoundException($"Vehicle with ID {inspection.VehicleId} not found.");
        }

        // Validate scheduled date is in the future
        if (inspection.ScheduledDate <= DateTime.UtcNow)
        {
            throw new ArgumentException("Scheduled date must be in the future.");
        }

        inspection.Status = "Pending";
        inspection.Report = string.Empty;
        
        var result = await _inspectionRepository.AddAsync(inspection);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = inspection.InspectorId,
            Action = "Schedule Inspection",
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

    public async Task CompleteInspectionAsync(Guid id, string report)
    {
        var inspection = await _inspectionRepository.GetByIdAsync(id);
        if (inspection == null)
        {
            throw new KeyNotFoundException($"Inspection with ID {id} not found.");
        }

        if (string.IsNullOrWhiteSpace(report))
        {
            throw new ArgumentException("Report cannot be empty.");
        }

        inspection.Status = "Completed";
        inspection.Report = report;
        
        await _inspectionRepository.UpdateAsync(inspection);

        // Log the action
        await _auditLogRepository.AddAsync(new AuditLog
        {
            UserId = inspection.InspectorId,
            Action = "Complete Inspection",
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
