using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetNet.Data;
using projetNet.DTOs;
using projetNet.Models;

namespace projetNet.Controllers.Api;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet("stats")]
    public async Task<ActionResult<DashboardStatsDto>> GetStats()
    {
        var totalUsers = await _userManager.Users.CountAsync();
        var totalBookings = await _context.Bookings.CountAsync();
        var totalVehicles = await _context.Vehicles.CountAsync();
        var totalRevenue = await _context.Bookings.SumAsync(b => b.TotalAmount);
        
        // Mock data for chart - in real app, group by created date
        var bookingsPerDay = new List<DailyBookingStats>();
        var today = DateTime.Today;
        for (int i = 6; i >= 0; i--)
        {
            var date = today.AddDays(-i);
            // This is just a placeholder logic, ideally we query the database with GroupBy
            bookingsPerDay.Add(new DailyBookingStats 
            { 
                Date = date.ToString("MMM dd"), 
                Count = new Random().Next(1, 10) 
            });
        }

        return Ok(new DashboardStatsDto
        {
            TotalUsers = totalUsers,
            TotalBookings = totalBookings,
            TotalVehicles = totalVehicles,
            TotalRevenue = totalRevenue,
            BookingsPerDay = bookingsPerDay
        });
    }
}
