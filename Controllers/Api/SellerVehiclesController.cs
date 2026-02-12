using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetNet.Helpers;
using projetNet.Models;
using projetNet.Services.ServiceContracts;
using System.Security.Claims;

namespace projetNet.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class SellerVehiclesController : ControllerBase
{
    private readonly IVehicleService _vehicleService;
    private readonly IInspectionService _inspectionService;
    private readonly IImageService _imageService;
    private readonly UserManager<ApplicationUser> _userManager;

    public SellerVehiclesController(
        IVehicleService vehicleService,
        IInspectionService inspectionService,
        IImageService imageService,
        UserManager<ApplicationUser> userManager)
    {
        _vehicleService = vehicleService;
        _inspectionService = inspectionService;
        _imageService = imageService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetMyVehicles([FromQuery] string? status)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        IEnumerable<Vehicle> vehicles;
        if (string.IsNullOrEmpty(status))
            vehicles = await _vehicleService.GetByOwnerIdAsync(userId);
        else
            vehicles = await _vehicleService.GetByStatusAndOwnerAsync(status, userId);

        return Ok(vehicles);
    }

    [HttpGet("brands")]
    [AllowAnonymous]
    public IActionResult GetBrands()
    {
        return Ok(VehicleData.BrandsWithModels);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] VehicleCreateRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var vehicle = new Vehicle
        {
            Vin = request.Vin,
            Brand = request.Brand,
            Model = request.Model,
            Year = request.Year,
            Price = request.Price,
            RentalPrice = request.RentalPrice,
            Mileage = request.Mileage,
            Location = request.Location,
            Description = request.Description,
            OwnerId = userId
        };

        if (request.ImageFile != null && request.ImageFile.Length > 0)
        {
            await using var stream = request.ImageFile.OpenReadStream();
            vehicle.ImageUrl = await _imageService.UploadImageAsync(stream, request.ImageFile.FileName, "vehicles");
        }

        await _vehicleService.CreateAsync(vehicle, userId);
        return Ok(vehicle);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromForm] VehicleUpdateRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var existing = await _vehicleService.GetByIdAsync(id);
        if (existing == null) return NotFound();
        if (existing.OwnerId != userId) return Forbid();

        existing.Vin = request.Vin;
        existing.Brand = request.Brand;
        existing.Model = request.Model;
        existing.Year = request.Year;
        existing.Price = request.Price;
        existing.RentalPrice = request.RentalPrice;
        existing.Mileage = request.Mileage;
        existing.Location = request.Location;
        existing.Description = request.Description;
        existing.Status = "pending";

        if (request.ImageFile != null && request.ImageFile.Length > 0)
        {
            if (!string.IsNullOrEmpty(existing.ImageUrl))
                await _imageService.DeleteImageAsync(existing.ImageUrl);

            await using var stream = request.ImageFile.OpenReadStream();
            existing.ImageUrl = await _imageService.UploadImageAsync(stream, request.ImageFile.FileName, "vehicles");
        }

        await _vehicleService.UpdateAsync(existing);
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var vehicle = await _vehicleService.GetByIdAsync(id);
        if (vehicle == null) return NotFound();
        if (vehicle.OwnerId != userId) return Forbid();

        await _vehicleService.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("{id}/reason")]
    public async Task<IActionResult> GetDeclineReason(Guid id)
    {
        var inspections = await _inspectionService.GetByVehicleIdAsync(id);
        var inspection = inspections.FirstOrDefault();
        var vehicle = await _vehicleService.GetByIdAsync(id);

        return Ok(new
        {
            vehicle,
            inspection = inspection != null ? new { inspection.Id, inspection.VehicleId, inspection.InspectorId, inspection.Reason } : null
        });
    }
}

public class VehicleCreateRequest
{
    public string Vin { get; set; } = "";
    public string Brand { get; set; } = "";
    public string? Model { get; set; }
    public int Year { get; set; }
    public decimal? Price { get; set; }
    public decimal? RentalPrice { get; set; }
    public int? Mileage { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
    public IFormFile? ImageFile { get; set; }
}

public class VehicleUpdateRequest
{
    public string Vin { get; set; } = "";
    public string Brand { get; set; } = "";
    public string? Model { get; set; }
    public int Year { get; set; }
    public decimal? Price { get; set; }
    public decimal? RentalPrice { get; set; }
    public int? Mileage { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
    public IFormFile? ImageFile { get; set; }
}
