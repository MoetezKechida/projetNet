using MongoDB.Driver;
using projetNet.Data;

namespace projetNet.Repositories;

public interface IAuditLogRepository : IMongoRepository<AuditLog>
{
    Task<IEnumerable<AuditLog>> GetByUserIdAsync(string userId);
    Task<IEnumerable<AuditLog>> GetByEntityTypeAsync(string entityType);
    Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
}

public class AuditLogRepository : MongoRepository<AuditLog>, IAuditLogRepository
{
    public AuditLogRepository(IMongoContext mongoContext) 
        : base(mongoContext, "auditlogs")
    {
    }

    public async Task<IEnumerable<AuditLog>> GetByUserIdAsync(string userId)
    {
        var filter = Builders<AuditLog>.Filter.Eq(a => a.UserId, userId);
        return await _collection
            .Find(filter)
            .SortByDescending(a => a.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<AuditLog>> GetByEntityTypeAsync(string entityType)
    {
        var filter = Builders<AuditLog>.Filter.Eq(a => a.EntityType, entityType);
        return await _collection
            .Find(filter)
            .SortByDescending(a => a.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var filter = Builders<AuditLog>.Filter.And(
            Builders<AuditLog>.Filter.Gte(a => a.Timestamp, startDate),
            Builders<AuditLog>.Filter.Lte(a => a.Timestamp, endDate)
        );
        return await _collection
            .Find(filter)
            .SortByDescending(a => a.Timestamp)
            .ToListAsync();
    }
}
