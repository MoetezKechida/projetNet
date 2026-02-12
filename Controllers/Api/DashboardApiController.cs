using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetNet.Data;
using projetNet.Models;
using Microsoft.EntityFrameworkCore;

namespace projetNet.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class DashboardController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var user = await _userManager.FindByIdAsync(userId!);
        if (user == null) return Unauthorized();

        var roles = await _userManager.GetRolesAsync(user);
        if (!roles.Contains("Admin")) return Forbid();

        var sales = await _context.VehiculeSales.ToListAsync();
        var bookings = await _context.Bookings.ToListAsync();

        return Ok(new { sales, bookings });
    }

    [HttpGet("inspectors")]
    public async Task<IActionResult> GetInspectors()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var user = await _userManager.FindByIdAsync(userId!);
        if (user == null) return Unauthorized();

        var roles = await _userManager.GetRolesAsync(user);
        if (!roles.Contains("Admin")) return Forbid();

        var inspectorRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Inspector");
        if (inspectorRole == null) return Ok(new List<object>());

        var inspectorUserIds = await _context.UserRoles
            .Where(ur => ur.RoleId == inspectorRole.Id)
            .Select(ur => ur.UserId)
            .ToListAsync();

        var inspectors = await _context.Users
            .Where(u => inspectorUserIds.Contains(u.Id))
            .Select(u => new { u.Id, u.Email, u.FirstName, u.LastName, u.PhoneNumber })
            .ToListAsync();

        return Ok(inspectors);
    }

    [HttpPost("inspectors")]
    public async Task<IActionResult> CreateInspector([FromBody] CreateInspectorRequest request)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var adminUser = await _userManager.FindByIdAsync(userId!);
        if (adminUser == null) return Unauthorized();

        var roles = await _userManager.GetRolesAsync(adminUser);
        if (!roles.Contains("Admin")) return Forbid();

        var inspector = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            IsEmailVerified = true,
            CreatedAt = DateTime.UtcNow
        };

        var result = await _userManager.CreateAsync(inspector, request.Password);
        if (!result.Succeeded)
            return BadRequest(new { errors = result.Errors.Select(e => new { e.Code, e.Description }) });

        await _userManager.AddToRoleAsync(inspector, "Inspector");

        return Ok(new { inspector.Id, inspector.Email, inspector.FirstName, inspector.LastName });
    }

    [HttpPut("inspectors/{id}")]
    public async Task<IActionResult> UpdateInspector(string id, [FromBody] UpdateInspectorRequest request)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var adminUser = await _userManager.FindByIdAsync(userId!);
        if (adminUser == null) return Unauthorized();

        var adminRoles = await _userManager.GetRolesAsync(adminUser);
        if (!adminRoles.Contains("Admin")) return Forbid();

        var inspector = await _userManager.FindByIdAsync(id);
        if (inspector == null) return NotFound();

        inspector.Email = request.Email;
        inspector.UserName = request.Email;
        inspector.FirstName = request.FirstName;
        inspector.LastName = request.LastName;

        await _userManager.UpdateAsync(inspector);
        return Ok(new { inspector.Id, inspector.Email, inspector.FirstName, inspector.LastName });
    }

    [HttpDelete("inspectors/{id}")]
    public async Task<IActionResult> DeleteInspector(string id)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var adminUser = await _userManager.FindByIdAsync(userId!);
        if (adminUser == null) return Unauthorized();

        var adminRoles = await _userManager.GetRolesAsync(adminUser);
        if (!adminRoles.Contains("Admin")) return Forbid();

        var inspector = await _userManager.FindByIdAsync(id);
        if (inspector == null) return NotFound();

        await _userManager.DeleteAsync(inspector);
        return NoContent();
    }
}

public record CreateInspectorRequest(string Email, string FirstName, string LastName, string Password);
public record UpdateInspectorRequest(string Email, string FirstName, string LastName);
