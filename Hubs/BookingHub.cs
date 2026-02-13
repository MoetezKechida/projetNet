using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace projetNet.Hubs;

[Authorize(AuthenticationSchemes = "Bearer")]
public class BookingHub : Hub
{
    /// <summary>
    /// On connect, add the authenticated user to a personal group
    /// so we can push targeted notifications via group name = userId.
    /// </summary>
    public override async Task OnConnectedAsync()
    {
        var userId = Context.UserIdentifier;
        if (!string.IsNullOrEmpty(userId))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.UserIdentifier;
        if (!string.IsNullOrEmpty(userId))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }

        await base.OnDisconnectedAsync(exception);
    }
}
