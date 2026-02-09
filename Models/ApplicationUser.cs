using Microsoft.AspNetCore.Identity;

namespace projetNet.Models;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsVerifiedSeller { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}
