using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetNet.Data;
using projetNet.Models;

namespace projetNet.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class DebugController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public DebugController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet("database-info")]
    public async Task<ActionResult> GetDatabaseInfo()
    {
        try
        {
            // Get connection string (hide password)
            var connectionString = _context.Database.GetConnectionString();
            var sanitizedConnection = connectionString?.Replace("password=?Joseph008?", "password=***");

            // Check database connection
            var canConnect = await _context.Database.CanConnectAsync();

            // Get all users
            var users = await _userManager.Users.ToListAsync();

            // Get table names by trying to query them
            var vehicleCount = await _context.Vehicles.CountAsync();
            var offerCount = await _context.Offers.CountAsync();
            var inspectionCount = await _context.Inspections.CountAsync();

            return Ok(new
            {
                connectionString = sanitizedConnection,
                canConnect = canConnect,
                databaseProvider = _context.Database.ProviderName,
                totalUsers = users.Count,
                users = users.Select(u => new
                {
                    u.Id,
                    u.Email,
                    u.UserName,
                    u.EmailConfirmed,
                    u.PhoneNumber,
                    u.PhoneNumberConfirmed,
                    u.CreatedAt,
                    u.RefreshToken,
                    HasRefreshToken = !string.IsNullOrEmpty(u.RefreshToken)
                }),
                tableInfo = new
                {
                    vehicles = vehicleCount,
                    offers = offerCount,
                    inspections = inspectionCount
                }
            });
        }
        catch (Exception ex)
        {
            return Ok(new
            {
                error = ex.Message,
                stackTrace = ex.StackTrace,
                innerException = ex.InnerException?.Message
            });
        }
    }

    [HttpGet("test-user-creation")]
    public async Task<ActionResult> TestUserCreation()
    {
        try
        {
            var testEmail = $"debug.test.{Guid.NewGuid().ToString().Substring(0, 8)}@test.com";
            
            var user = new ApplicationUser
            {
                UserName = testEmail,
                Email = testEmail,
                EmailConfirmed = true,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, "Test123!");
            
            if (result.Succeeded)
            {
                // Verify the user was created
                var createdUser = await _userManager.FindByEmailAsync(testEmail);
                var allUsers = await _userManager.Users.ToListAsync();

                return Ok(new
                {
                    success = true,
                    message = "User created successfully",
                    userId = createdUser?.Id,
                    email = createdUser?.Email,
                    totalUsersInDB = allUsers.Count,
                    allUserEmails = allUsers.Select(u => u.Email).ToList()
                });
            }
            else
            {
                return Ok(new
                {
                    success = false,
                    errors = result.Errors.Select(e => e.Description).ToList()
                });
            }
        }
        catch (Exception ex)
        {
            return Ok(new
            {
                error = ex.Message,
                stackTrace = ex.StackTrace,
                innerException = ex.InnerException?.Message
            });
        }
    }

    [HttpGet("check-tables")]
    public async Task<ActionResult> CheckTables()
    {
        try
        {
            // Execute raw SQL to check tables
            var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SHOW TABLES;";
            
            var tables = new List<string>();
            using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                tables.Add(reader.GetString(0));
            }

            return Ok(new
            {
                database = connection.Database,
                server = connection.DataSource,
                tables = tables,
                hasAspNetUsers = tables.Contains("AspNetUsers")
            });
        }
        catch (Exception ex)
        {
            return Ok(new
            {
                error = ex.Message,
                stackTrace = ex.StackTrace
            });
        }
    }
}
