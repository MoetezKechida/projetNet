using Microsoft.AspNetCore.Identity;

namespace projetNet.Models;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsVerifiedSeller { get; set; }
    public bool IsEmailVerified { get; set; }
    public bool IsPhoneVerified { get; set; }
    
    public double SellerRating { get; set; }
    public int SellerReviewCount { get; set; }

}
