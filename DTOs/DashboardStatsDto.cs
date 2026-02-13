namespace projetNet.DTOs;

public class DashboardStatsDto
{
    public int TotalUsers { get; set; }
    public int TotalBookings { get; set; }
    public int TotalVehicles { get; set; }
    public decimal TotalRevenue { get; set; }
    public List<DailyBookingStats> BookingsPerDay { get; set; } = new();
}

public class DailyBookingStats
{
    public string Date { get; set; } = string.Empty;
    public int Count { get; set; }
}
