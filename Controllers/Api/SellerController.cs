using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetNet.DTOs;
using projetNet.Models;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers.Api;

[Authorize(Roles = "Seller")]
[Route("api/[controller]")]
[ApiController]
public class SellerController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly IVehicleService _vehicleService;
    private readonly UserManager<ApplicationUser> _userManager;

    public SellerController(
        IBookingService bookingService,
        IVehicleService vehicleService,
        UserManager<ApplicationUser> userManager)
    {
        _bookingService = bookingService;
        _vehicleService = vehicleService;
        _userManager = userManager;
    }

    [HttpGet("bookings")]
    public async Task<ActionResult<IEnumerable<BookingNotificationDto>>> GetBookings()
    {
        var userId = _userManager.GetUserId(User);
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var bookings = await _bookingService.GetBySellerIdAsync(userId);
        
        var result = new List<BookingNotificationDto>();
        foreach (var b in bookings)
        {
            var vehicle = await _vehicleService.GetByIdAsync(b.VehicleId);
            var buyer = await _userManager.FindByIdAsync(b.BuyerId);
            
            result.Add(new BookingNotificationDto
            {
                Id = b.Id,
                VehicleId = b.VehicleId,
                VehicleModel = vehicle != null ? $"{vehicle.Brand} {vehicle.Model}" : "Unknown Vehicle",
                BuyerName = buyer != null ? $"{buyer.FirstName} {buyer.LastName}" : "Unknown Buyer",
                BookingType = b.BookingType,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                TotalAmount = b.TotalAmount,
                CreatedAt = DateTime.UtcNow // Store CreatedAt in Booking entity for better accuracy
            });
        }
        
        return Ok(result.OrderByDescending(x => x.CreatedAt));
    }
}
