namespace projetNet.Services;

public interface IAuditLogService
{
    Task<AuditLog?> GetByIdAsync(string id);
    Task<IEnumerable<AuditLog>> GetAllAsync();
    Task<IEnumerable<AuditLog>> GetByUserIdAsync(string userId);
    Task<IEnumerable<AuditLog>> GetByEntityTypeAsync(string entityType);
    Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<AuditLog> LogActionAsync(string userId, string action, string entityType);
}
