using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRChat.Data;
using System.Security.Claims;
using System.Security.Principal;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        
        /// <summary>
        /// 特定の相手にメッセージを送信する
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>        
        public async Task SendPrivateMessage(string user, string message)
        {                       
            await Clients.User(user).SendAsync("ReceivePrivateMessage",
                                               $"{Context.UserIdentifier}: {message}");
        }

        /// <summary>
        /// グループに所属するメンバーにメッセージを送る
        /// </summary>
        /// <param name="group"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessageGroup(string group, string message)
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", message);
        }

        /// <summary>
        /// グループに現在のConnectionを追加する
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        /// <summary>
        /// Groupから現在のConnectionを削除する
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }        
    }


}
