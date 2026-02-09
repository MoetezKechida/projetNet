namespace projetNet.DTOs.Common;

/// <summary>
/// Standard error response returned by the API for all error scenarios.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// HTTP status code
    /// </summary>
    public int Status { get; set; }
    
    /// <summary>
    /// High-level error message
    /// </summary>
    public string Message { get; set; } = string.Empty;
    
    /// <summary>
    /// Detailed validation errors (if applicable)
    /// </summary>
    public IEnumerable<ErrorDetail>? Errors { get; set; }
    
    /// <summary>
    /// Trace ID for correlating logs
    /// </summary>
    public string? TraceId { get; set; }
    
    /// <summary>
    /// Timestamp when the error occurred
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// Detailed error information for specific fields or validation rules.
/// </summary>
public class ErrorDetail
{
    /// <summary>
    /// Field or property name that failed validation
    /// </summary>
    public string Field { get; set; } = string.Empty;
    
    /// <summary>
    /// Error message describing the validation failure
    /// </summary>
    public string Message { get; set; } = string.Empty;
}
