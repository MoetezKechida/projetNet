using Microsoft.EntityFrameworkCore;
using projetNet.Data;
using projetNet.Models;
using projetNet.Repositories.RepositoryContracts;

namespace projetNet.Repositories.Repositories;

public interface IInspectionRepository : IRepository<Inspection>
{
    Task<IEnumerable<Inspection>> GetByVehicleIdAsync(Guid vehicleId);
    Task<IEnumerable<Inspection>> GetByInspectorIdAsync(string inspectorId);
    Task<IEnumerable<Inspection>> GetPendingInspectionsAsync();
}

public class InspectionRepository : Repository<Inspection>, IInspectionRepository
{
    public InspectionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Inspection>> GetByVehicleIdAsync(Guid vehicleId)
    {
        return await _dbSet
            .Where(i => i.VehicleId == vehicleId)
            .OrderByDescending(i => i.ScheduledDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Inspection>> GetByInspectorIdAsync(string inspectorId)
    {
        return await _dbSet
            .Where(i => i.InspectorId == inspectorId)
            .OrderByDescending(i => i.ScheduledDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Inspection>> GetPendingInspectionsAsync()
    {
        return await _dbSet
            .Where(i => i.Status == "Pending")
            .OrderBy(i => i.ScheduledDate)
            .ToListAsync();
    }
}
