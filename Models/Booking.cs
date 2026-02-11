namespace projetNet.Models;

public class Booking
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public required string BuyerId { get; set; }
    public required string BookingType { get; set; } // "Buy" or "Rent"
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalAmount { get; set; }
}