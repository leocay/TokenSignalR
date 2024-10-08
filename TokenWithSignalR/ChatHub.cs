using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

[Authorize]
public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"User connected: {Context.UserIdentifier}");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"User disconnected: {Context.UserIdentifier}");
        return base.OnDisconnectedAsync(exception);
    }
}
