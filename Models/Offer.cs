using Microsoft.AspNetCore.Identity;

namespace projetNet.Models;

public class Offer
{
    public Guid Id { get; set; }
    public required string Type { get; set; } // Sale or Rent
    public decimal Price { get; set; }
    public required string Status { get; set; }
    public Guid VehicleId { get; set; }
    public required string SellerId { get; set; }
}