using projetNet.Repositories;
using projetNet.Repositories.Repositories;
using projetNet.Services.ServiceContracts;

namespace projetNet.Services.Services;

public class AuditLogService : IAuditLogService
{
    private readonly IAuditLogRepository _auditLogRepository;

    public AuditLogService(IAuditLogRepository auditLogRepository)
    {
        _auditLogRepository = auditLogRepository;
    }

    public async Task<AuditLog?> GetByIdAsync(string id)
    {
        return await _auditLogRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<AuditLog>> GetAllAsync()
    {
        return await _auditLogRepository.GetAllAsync();
    }

    public async Task<IEnumerable<AuditLog>> GetByUserIdAsync(string userId)
    {
        return await _auditLogRepository.GetByUserIdAsync(userId);
    }

    public async Task<IEnumerable<AuditLog>> GetByEntityTypeAsync(string entityType)
    {
        return await _auditLogRepository.GetByEntityTypeAsync(entityType);
    }

    public async Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _auditLogRepository.GetByDateRangeAsync(startDate, endDate);
    }

    public async Task<AuditLog> LogActionAsync(string userId, string action, string entityType)
    {
        var auditLog = new AuditLog
        {
            UserId = userId,
            Action = action,
            EntityType = entityType,
            Timestamp = DateTime.UtcNow
        };

        return await _auditLogRepository.AddAsync(auditLog);
    }
}
