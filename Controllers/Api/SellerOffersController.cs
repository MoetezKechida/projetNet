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
public class SellerOffersController : ControllerBase
{
    private readonly IOfferService _offerService;
    private readonly IVehicleService _vehicleService;
    private readonly UserManager<ApplicationUser> _userManager;

    public SellerOffersController(
        IOfferService offerService,
        IVehicleService vehicleService,
        UserManager<ApplicationUser> userManager)
    {
        _offerService = offerService;
        _vehicleService = vehicleService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetMyOffers()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var offers = await _offerService.GetBySellerIdAsync(userId);
        return Ok(offers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOfferDetails(Guid id)
    {
        var offer = await _offerService.GetByIdAsync(id);
        if (offer == null) return NotFound();

        var vehicle = await _vehicleService.GetByIdAsync(offer.VehicleId);

        return Ok(new
        {
            offer,
            vehicle = vehicle != null ? new { vehicle.Id, vehicle.Brand, vehicle.Model, vehicle.Year, vehicle.ImageUrl, vehicle.Price, vehicle.RentalPrice } : null
        });
    }

    [HttpGet("my-vehicles")]
    public async Task<IActionResult> GetMyVehicles()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var vehicles = await _vehicleService.GetByOwnerIdAsync(userId);
        return Ok(vehicles.Select(v => new { v.Id, v.Brand, v.Model, v.Year }));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOfferRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var offer = new Offer
        {
            Type = request.Type,
            Price = request.Price,
            Status = "Active",
            VehicleId = request.VehicleId,
            SellerId = userId
        };

        await _offerService.CreateAsync(offer);
        return Ok(offer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOfferRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var existing = await _offerService.GetByIdAsync(id);
        if (existing == null) return NotFound();
        if (existing.SellerId != userId) return Forbid();

        existing.Type = request.Type;
        existing.Price = request.Price;
        existing.VehicleId = request.VehicleId;
        existing.Status = request.Status;

        await _offerService.UpdateAsync(existing);
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var offer = await _offerService.GetByIdAsync(id);
        if (offer == null) return NotFound();
        if (offer.SellerId != userId) return Forbid();

        await _offerService.DeleteAsync(id);
        return NoContent();
    }
}

public record CreateOfferRequest(string Type, decimal Price, Guid VehicleId);
public record UpdateOfferRequest(string Type, decimal Price, Guid VehicleId, string Status);
