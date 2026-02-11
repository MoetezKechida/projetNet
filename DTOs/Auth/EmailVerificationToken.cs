using projetNet.Models;

namespace projetNet.DTOs.Auth;

public sealed class EmailVerificationToken
{
    public Guid Id { get; set; }
    public string UserId { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public ApplicationUser User { get; set; } = null!;
}
