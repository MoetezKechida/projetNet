using Microsoft.EntityFrameworkCore;
using projetNet.Data;
using projetNet.Models;
using projetNet.Repositories.RepositoryContracts;

namespace projetNet.Repositories.Repositories;

public interface IInspectionRepository : IRepository<Inspection>
{
    Task<IEnumerable<Inspection>> GetByVehicleIdAsync(Guid vehicleId);
    Task<IEnumerable<Inspection>> GetByInspectorIdAsync(string inspectorId);
    
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
            
            .ToListAsync();
    }

    public async Task<IEnumerable<Inspection>> GetByInspectorIdAsync(string inspectorId)
    {
        return await _dbSet
            .Where(i => i.InspectorId == inspectorId)
            
            .ToListAsync();
    }

    
}
