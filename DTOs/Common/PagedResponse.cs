namespace projetNet.DTOs.Common;

/// <summary>
/// Generic paginated response wrapper for list endpoints.
/// </summary>
/// <typeparam name="T">Type of items in the response</typeparam>
public class PagedResponse<T>
{
    /// <summary>
    /// Items for the current page
    /// </summary>
    public IEnumerable<T> Items { get; set; } = new List<T>();
    
    /// <summary>
    /// Current page number (1-based)
    /// </summary>
    public int Page { get; set; }
    
    /// <summary>
    /// Number of items per page
    /// </summary>
    public int PageSize { get; set; }
    
    /// <summary>
    /// Total number of items across all pages
    /// </summary>
    public int TotalItems { get; set; }
    
    /// <summary>
    /// Total number of pages
    /// </summary>
    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
    
    /// <summary>
    /// Indicates if there is a previous page
    /// </summary>
    public bool HasPrevious => Page > 1;
    
    /// <summary>
    /// Indicates if there is a next page
    /// </summary>
    public bool HasNext => Page < TotalPages;
}

/// <summary>
/// Request parameters for pagination
/// </summary>
public class PaginationParams
{
    private const int MaxPageSize = 100;
    private int _pageSize = 20;
    
    /// <summary>
    /// Page number (1-based, default: 1)
    /// </summary>
    public int Page { get; set; } = 1;
    
    /// <summary>
    /// Items per page (default: 20, max: 100)
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}
