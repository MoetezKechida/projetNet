using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace projetNet.Authorization;

public class VerifiedSellerRequirement : IAuthorizationRequirement { }

public class VerifiedSellerHandler : AuthorizationHandler<VerifiedSellerRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        VerifiedSellerRequirement requirement)
    {
        var isVerified = context.User.Claims
            .Any(c => c.Type == "IsVerifiedSeller" && c.Value == "True");
        
        if (isVerified)
        {
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    }
}


public class VehicleOwnerRequirement : IAuthorizationRequirement 
{
    public Guid VehicleId { get; }
    
    public VehicleOwnerRequirement(Guid vehicleId)
    {
        VehicleId = vehicleId;
    }
}
