using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ChatServer
{
    public class ChatHub : Hub
    {
        // Dictionary to map usernames to their connection IDs
        private static readonly ConcurrentDictionary<string, string> Users = new ConcurrentDictionary<string, string>();

        // Called when a client connects
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        // Called when a client disconnects
        public override Task OnDisconnectedAsync(Exception exception)
        {
            // Remove the user from the dictionary on disconnection
            var user = Users.FirstOrDefault(u => u.Value == Context.ConnectionId);
            if (!string.IsNullOrEmpty(user.Key))
            {
                Users.TryRemove(user.Key, out _);
            }

            return base.OnDisconnectedAsync(exception);
        }

        // Method to register a username with the connection ID
        public async Task RegisterUser(string username)
        {
            Users[username] = Context.ConnectionId;
            await Clients.Caller.SendAsync("Registered", $"Welcome {username}! You are now connected.");
        }

        // Method to send a private message to a specific user
        public async Task SendMessageToUser(string sender, string recipient, string message)
        {
            if (Users.TryGetValue(recipient, out var connectionId))
            {
                // Send message to the recipient
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", sender, message);
            }
            else
            {
                // Inform sender if the recipient does not exist
                await Clients.Caller.SendAsync("ReceiveMessage", "System", $"User {recipient} not found.");
            }
        }
    }
}
