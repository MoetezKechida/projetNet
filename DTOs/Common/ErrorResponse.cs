namespace projetNet.DTOs.Common;


public class ErrorResponse
{
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
    public IEnumerable<ErrorDetail>? Errors { get; set; }
    public string? TraceId { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}


public class ErrorDetail
{
    public string Field { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
