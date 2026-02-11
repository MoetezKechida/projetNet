using Microsoft.AspNetCore.Identity;

namespace projetNet.Models;

public class Booking
{
    public Guid Id { get; set; }
    public Guid OfferId { get; set; }
    public required string BuyerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "attempt";
}