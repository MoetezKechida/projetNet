using projetNet.Models;

namespace projetNet.Models;

public class Inspection
{
    
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public string InspectorId { get; set; }
    public string Reason { get; set; }
    
}