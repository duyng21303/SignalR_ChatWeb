using System;
using System.Web;
using Microsoft.AspNetCore.SignalR;
namespace SimpleSignalR
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string fromUser, string massage)
        {
            Clients.All.SendAsync("ReceiveMessage", fromUser, massage);
        }
    }
}