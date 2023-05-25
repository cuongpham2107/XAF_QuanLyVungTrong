//using DXApplication.Blazor.Server.Models;
//using Microsoft.AspNetCore.SignalR;
//using MySqlX.XDevAPI;

//namespace DXApplication.Blazor.Server.Hubs
//{
//    public class ChatHub : Hub
//    {
//        public async Task SendMessage(string toUser, string fromUser, string message)
//        {
//            await Clients.All.SendAsync("ReceiveMessage", toUser, fromUser, message);

//        }
//    }
//}
