namespace projetNet.DTOs.Common;

public class CreateBookingDto
{
    public Guid VehicleId { get; set; }
    public string BookingType { get; set; } = "Buy"; // "Buy" or "Rent"
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
