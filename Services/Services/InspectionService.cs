using projetNet.Models;
using projetNet.Repositories.Repositories;
using projetNet.Services.ServiceContracts;

namespace projetNet.Services.Services;

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
