namespace projetNet.DTOs.Common;

public class PagedResponse<T>
{

    public IEnumerable<T> Items { get; set; } = new List<T>();
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
    public bool HasPrevious => Page > 1;
    public bool HasNext => Page < TotalPages;
}
public class PaginationParams
{
    private const int MaxPageSize = 100;
    private int _pageSize = 20;
    public int Page { get; set; } = 1;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}
