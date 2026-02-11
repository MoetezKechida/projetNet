using VehicleModel = projetNet.Models.Vehicle;

namespace projetNet.DTOs.Common;

public class VehiclePreviewViewModel
{
    public VehicleModel Vehicle { get; set; } = null!;
    public bool HasSalePrice { get; set; }
    public bool HasRentalPrice { get; set; }
}
