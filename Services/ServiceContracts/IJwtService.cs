using projetNet.Models;
using System.Security.Claims;

namespace projetNet.Services.ServiceContracts;

public interface IJwtService
{
    string GenerateAccessToken(ApplicationUser user, IList<string> roles);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    int GetTokenExpiryMinutes();
}