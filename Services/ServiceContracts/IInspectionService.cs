using projetNet.Models;

namespace projetNet.Services.ServiceContracts;

public interface IInspectionService
{
    Task<Inspection?> GetByIdAsync(Guid id);
    Task<IEnumerable<Inspection>> GetAllAsync();
    Task<IEnumerable<Inspection>> GetByVehicleIdAsync(Guid vehicleId);
    Task<IEnumerable<Inspection>> GetByInspectorIdAsync(string inspectorId);

    Task<Inspection> CreateAsync(Guid vehicleId, string inspectorId, string reason);
    Task UpdateInspectionAsync(Inspection inspection);
    
    Task DeleteAsync(Guid id);
}
