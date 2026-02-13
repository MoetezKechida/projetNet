using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using projetNet.DTOs;
using projetNet.DTOs.Common;
using projetNet.Hubs;
using projetNet.Models;
using projetNet.Services.ServiceContracts;
using System.Security.Claims;

namespace projetNet.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly IVehicleService _vehicleService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHubContext<BookingHub> _bookingHub;

    public BookingsController(
        IBookingService bookingService,
        IVehicleService vehicleService,
        UserManager<ApplicationUser> userManager,
        IHubContext<BookingHub> bookingHub)
    {
        _bookingService = bookingService;
        _vehicleService = vehicleService;
        _userManager = userManager;
        _bookingHub = bookingHub;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var booking = await _bookingService.CreateBookingAsync(
            dto.VehicleId, userId, dto.BookingType, dto.StartDate, dto.EndDate);

        // Look up vehicle + buyer to build the real-time notification
        var vehicle = await _vehicleService.GetByIdAsync(booking.VehicleId);
        var buyer = await _userManager.FindByIdAsync(userId);

        if (vehicle != null)
        {
            var notification = new BookingNotificationDto
            {
                Id = booking.Id,
                VehicleId = booking.VehicleId,
                VehicleModel = $"{vehicle.Brand} {vehicle.Model ?? ""}".Trim(),
                BuyerName = $"{buyer?.FirstName} {buyer?.LastName}".Trim(),
                BookingType = booking.BookingType,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                TotalAmount = booking.TotalAmount,
            };

            // Push notification to the vehicle owner (seller) via their personal group
            await _bookingHub.Clients.Group(vehicle.OwnerId)
                .SendAsync("NewBookingReceived", notification);
        }

        return Ok(booking);
    }

    [HttpGet("my-bookings")]
    public async Task<IActionResult> MyBookings()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var bookings = await _bookingService.GetByBuyerIdAsync(userId);
        var result = new List<object>();

        foreach (var booking in bookings)
        {
            var vehicle = await _vehicleService.GetByIdAsync(booking.VehicleId);
            var seller = vehicle != null ? await _userManager.FindByIdAsync(vehicle.OwnerId) : null;

            result.Add(new
            {
                booking = new { booking.Id, booking.VehicleId, booking.BuyerId, booking.BookingType, booking.StartDate, booking.EndDate, booking.TotalAmount, booking.Status },
                vehicle = vehicle != null ? new { vehicle.Id, vehicle.Brand, vehicle.Model, vehicle.Year, vehicle.ImageUrl, vehicle.Price, vehicle.RentalPrice } : null,
                user = seller != null ? new { seller.Id, seller.FirstName, seller.LastName, seller.Email, seller.PhoneNumber } : null
            });
        }

        return Ok(result);
    }

    [HttpGet("requests")]
    public async Task<IActionResult> Requests()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var bookings = await _bookingService.GetBySellerIdAsync(userId);
        var result = new List<object>();

        foreach (var booking in bookings)
        {
            var vehicle = await _vehicleService.GetByIdAsync(booking.VehicleId);
            var buyer = await _userManager.FindByIdAsync(booking.BuyerId);

            result.Add(new
            {
                booking = new { booking.Id, booking.VehicleId, booking.BuyerId, booking.BookingType, booking.StartDate, booking.EndDate, booking.TotalAmount, booking.Status },
                vehicle = vehicle != null ? new { vehicle.Id, vehicle.Brand, vehicle.Model, vehicle.Year, vehicle.ImageUrl, vehicle.Price, vehicle.RentalPrice } : null,
                user = buyer != null ? new { buyer.Id, buyer.FirstName, buyer.LastName, buyer.Email, buyer.PhoneNumber } : null
            });
        }

        return Ok(result);
    }

    [HttpPost("{id}/complete")]
    public async Task<IActionResult> CompleteTransaction(Guid id)
    {
        var booking = await _bookingService.GetByIdAsync(id);
        if (booking == null) return NotFound();

        await _bookingService.DeleteBookingAsync(id);
        return Ok(new { message = "Transaction completed" });
    }
}
