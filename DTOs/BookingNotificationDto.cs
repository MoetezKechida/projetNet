namespace projetNet.DTOs;

public class BookingNotificationDto
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public string VehicleModel { get; set; } = string.Empty;
    public string BuyerName { get; set; } = string.Empty;
    public string BookingType { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
