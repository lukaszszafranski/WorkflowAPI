using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WorkflowAPI.Chat
{
    public class MessageHub : Hub
    {
        public async Task NewMessage(Message msg)
        {
            await Clients.All.SendAsync("MessageReceived", msg);
        }
    }
}
