namespace projetNet.Models;

public class Vehicle
{
    public Guid Id { get; set; }
    public required string Vin { get; set; }
    public required string Brand { get; set; }
    public int Year { get; set; }
    public required string OwnerId { get; set; }
    
}
