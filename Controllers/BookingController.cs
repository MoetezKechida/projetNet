using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetNet.DTOs.Common;
using projetNet.Exceptions;
using projetNet.Models;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers;

[Authorize]
public class BookingController : Controller
{
    private readonly IBookingService _bookingService;
    private readonly IVehicleService _vehicleService;
    private readonly UserManager<ApplicationUser> _userManager;

    public BookingController(
        IBookingService bookingService,
        IVehicleService vehicleService,
        UserManager<ApplicationUser> userManager)
    {
        _bookingService = bookingService;
        _vehicleService = vehicleService;
        _userManager = userManager;
    }

    // POST: Booking/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] CreateBookingDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid booking data";
                return RedirectToAction("Preview", "VehicleListing", new { id = dto.VehicleId });
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var booking = await _bookingService.CreateBookingAsync(
                dto.VehicleId,
                user.Id,
                dto.BookingType,
                dto.StartDate,
                dto.EndDate
            );

            TempData["Success"] = "Your booking request has been submitted successfully!";
            
            return RedirectToAction("Preview", "VehicleListing", new { id = dto.VehicleId });
        }
        catch (NotFoundException ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("Index", "VehicleListing");
        }
        catch (InvalidOperationException ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction("Index", "VehicleListing");
        }
        catch (Exception)
        {
            TempData["Error"] = "An error occurred while creating the booking";
            return RedirectToAction("Index", "VehicleListing");
        }
    }

    // GET: Booking/MyBookings (for buyers)
    [Authorize(Policy = "RequireBuyer")]
    public async Task<IActionResult> MyBookings()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }

        var bookings = await _bookingService.GetByBuyerIdAsync(user.Id);
        return View(bookings);
    }

    // GET: Booking/Requests (for sellers)
    [Authorize(Policy = "RequireSeller")]
    public async Task<IActionResult> Requests()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }

        var bookings = await _bookingService.GetBySellerIdAsync(user.Id);
        return View(bookings);
    }
}
