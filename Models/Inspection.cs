using projetNet.Models;

namespace projetNet.Models;

public class Inspection
{
    
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public required string InspectorId { get; set; }
    public required string Report { get; set; }
    
}