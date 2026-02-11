using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetNet.DTOs.Auth;
using projetNet.Models;
using projetNet.Services.ServiceContracts;
using System.Security.Claims;

namespace projetNet.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<AuthController> _logger;

    public AuthController(
        IAuthService authService,
        UserManager<ApplicationUser> userManager,
        ILogger<AuthController> logger)
    {
        _authService = authService;
        _userManager = userManager;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
    {
        var response = await _authService.RegisterAsync(request);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
    {
        var response = await _authService.LoginAsync(request);
        return Ok(response);
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<AuthResponse>> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var response = await _authService.RefreshTokenAsync(request);
        return Ok(response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("change-password")]
    public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        await _authService.ChangePasswordAsync(userId, request);
        return Ok(new { message = "Password changed successfully" });
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        await _authService.RevokeRefreshTokenAsync(userId);
        return Ok(new { message = "Logged out successfully" });
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("me")]
    public async Task<ActionResult<UserInfo>> GetCurrentUser()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return NotFound();

        var roles = await _userManager.GetRolesAsync(user);

        return Ok(new UserInfo
        {
            Id = user.Id,
            Email = user.Email!,
            FullName = $"{user.FirstName} {user.LastName}".Trim(),
            Role = roles.FirstOrDefault(),
            IsEmailVerified = user.IsEmailVerified,
            IsPhoneVerified = user.IsPhoneVerified
        });
    }

    [HttpPost("verify-email")]
    [AllowAnonymous]
    public async Task<ActionResult> VerifyEmail([FromQuery] string email, [FromQuery] string token)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            return BadRequest("Email and token are required");

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return NotFound("User not found");

        if (user.EmailConfirmed)
            return BadRequest("Email already verified");

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return BadRequest($"Invalid or expired verification token: {errors}");
        }

        user.IsEmailVerified = true;
        await _userManager.UpdateAsync(user);

        _logger.LogInformation("Email verified for {Email}", email);
        return Ok(new { message = "Email verified successfully" });
    }

    [HttpPost("resend-verification")]
    [AllowAnonymous]
    public async Task<ActionResult> ResendVerification([FromBody] ResendVerificationRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return NotFound("User not found");

        if (user.EmailConfirmed)
            return BadRequest("Email already verified");

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        // TODO: Send verification email when IEmailService is fully configured
        _logger.LogInformation("Verification token generated for {Email}: {Token}", request.Email, token);
        return Ok(new { message = "Verification email sent" });
    }
}
