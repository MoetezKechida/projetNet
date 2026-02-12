using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetNet.Models;
using projetNet.Services.ServiceContracts;
using System.Security.Claims;

namespace projetNet.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class InspectionsController : ControllerBase
{
    private readonly IInspectionService _inspectionService;
    private readonly IVehicleService _vehicleService;
    private readonly UserManager<ApplicationUser> _userManager;

    public InspectionsController(
        IInspectionService inspectionService,
        IVehicleService vehicleService,
        UserManager<ApplicationUser> userManager)
    {
        _inspectionService = inspectionService;
        _vehicleService = vehicleService;
        _userManager = userManager;
    }

    // Get pending vehicles to inspect
    [HttpGet("pending-vehicles")]
    public async Task<IActionResult> GetPendingVehicles([FromQuery] string? brand)
    {
        var vehicles = await _vehicleService.GetAllAsync();
        var pending = vehicles.Where(v => v.Status == "pending");

        if (!string.IsNullOrEmpty(brand))
            pending = pending.Where(v => v.Brand == brand);

        return Ok(pending);
    }

    // Get inspector's inspections
    [HttpGet]
    public async Task<IActionResult> GetMyInspections()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var inspections = await _inspectionService.GetByInspectorIdAsync(userId);
        return Ok(inspections);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var inspection = await _inspectionService.GetByIdAsync(id);
        if (inspection == null) return NotFound();
        return Ok(inspection);
    }

    // Decline a vehicle (create inspection with reason)
    [HttpPost("decline")]
    public async Task<IActionResult> Decline([FromBody] DeclineVehicleRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        await _inspectionService.CreateAsync(request.VehicleId, userId, request.Reason);
        return Ok(new { message = "Vehicle declined" });
    }

    // Accept a vehicle
    [HttpPost("{vehicleId}/accept")]
    public async Task<IActionResult> Accept(Guid vehicleId)
    {
        var vehicle = await _vehicleService.GetByIdAsync(vehicleId);
        if (vehicle == null) return NotFound();

        vehicle.Status = "accepted";
        await _vehicleService.UpdateAsync(vehicle);

        return Ok(new { message = "Vehicle accepted" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInspectionRequest request)
    {
        var existing = await _inspectionService.GetByIdAsync(id);
        if (existing == null) return NotFound();

        existing.Reason = request.Reason;
        await _inspectionService.UpdateInspectionAsync(existing);
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _inspectionService.DeleteAsync(id);
        return NoContent();
    }
}

public record DeclineVehicleRequest(Guid VehicleId, string Reason);
public record UpdateInspectionRequest(string Reason);
