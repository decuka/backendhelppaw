// WebAPI/Hubs/ChatHub.cs
using Microsoft.AspNetCore.SignalR;

namespace HelPaw.WebAPI.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
