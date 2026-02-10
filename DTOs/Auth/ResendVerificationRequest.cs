namespace projetNet.DTOs.Auth;

public record ResendVerificationRequest
{
    public required string Email { get; init; }
}
