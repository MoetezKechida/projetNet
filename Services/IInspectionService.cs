using projetNet.Models;

namespace projetNet.Services;

public interface IInspectionService
{
    Task<Inspection?> GetByIdAsync(Guid id);
    Task<IEnumerable<Inspection>> GetAllAsync();
    Task<IEnumerable<Inspection>> GetByVehicleIdAsync(Guid vehicleId);
    Task<IEnumerable<Inspection>> GetByInspectorIdAsync(string inspectorId);
    Task<IEnumerable<Inspection>> GetPendingInspectionsAsync();
    Task<Inspection> ScheduleInspectionAsync(Inspection inspection);
    Task UpdateInspectionAsync(Inspection inspection);
    Task CompleteInspectionAsync(Guid id, string report);
    Task DeleteAsync(Guid id);
}
