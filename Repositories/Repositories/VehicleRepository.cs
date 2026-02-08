using Microsoft.EntityFrameworkCore;
using projetNet.Data;
using projetNet.Models;
using projetNet.Repositories.RepositoryContracts;

namespace projetNet.Repositories.Repositories;

public interface IVehicleRepository : IRepository<Vehicle>
{
    Task<IEnumerable<Vehicle>> GetByOwnerIdAsync(string ownerId);
    Task<Vehicle?> GetByVinAsync(string vin);
    Task<IEnumerable<Vehicle>> SearchAsync(string? brand, int? minYear, int? maxYear);
}

public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Vehicle>> GetByOwnerIdAsync(string ownerId)
    {
        return await _dbSet
            .Where(v => v.OwnerId == ownerId)
            .ToListAsync();
    }

    public async Task<Vehicle?> GetByVinAsync(string vin)
    {
        return await _dbSet
            .FirstOrDefaultAsync(v => v.Vin == vin);
    }

    public async Task<IEnumerable<Vehicle>> SearchAsync(string? brand, int? minYear, int? maxYear)
    {
        var query = _dbSet.AsQueryable();

        if (!string.IsNullOrEmpty(brand))
            query = query.Where(v => v.Brand.Contains(brand));

        if (minYear.HasValue)
            query = query.Where(v => v.Year >= minYear.Value);

        if (maxYear.HasValue)
            query = query.Where(v => v.Year <= maxYear.Value);

        return await query.ToListAsync();
    }
}
