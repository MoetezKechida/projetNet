using System.ComponentModel.DataAnnotations;
using projetNet.Constants;

namespace projetNet.DTOs.Auth;

public record RegisterRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string ConfirmPassword { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string PhoneNumber { get; init; }
    public string UserType { get; init; } = Roles.Buyer;
}

public record LoginRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}

public record AuthResponse
{
    public required string Token { get; init; }
    public required string RefreshToken { get; init; }
    public DateTime ExpiresAt { get; init; }
    public required UserInfo User { get; init; }
}

public record UserInfo
{
    public required string Id { get; init; }
    public required string Email { get; init; }
    public required string FullName { get; init; }
    public string? Role { get; init; }
    public bool IsEmailVerified { get; init; }
    public bool IsPhoneVerified { get; init; }
}

public record RefreshTokenRequest
{
    public required string RefreshToken { get; init; }
}

public record ChangePasswordRequest
{
    public required string CurrentPassword { get; init; }
    public required string NewPassword { get; init; }
    public required string ConfirmNewPassword { get; init; }
}
