namespace projetNet.Models;

public class Vehicle
{
    public Guid Id { get; set; }
    public required string Vin { get; set; }
    public required string Brand { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
    public required string OwnerId { get; set; }
    public string? ImageUrl { get; set; }
    public decimal? Price { get; set; }
    
    public decimal? RentalPrice { get; set; }
    
    public string? Description { get; set; }
    public int? Mileage { get; set; }
    public string? Location { get; set; }
    public string? Status  { get; set; }
    
    
    
    
}
