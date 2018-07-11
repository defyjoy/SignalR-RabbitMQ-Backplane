using EasyNetQ;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRRAbbitMQBackplane.SignalRHubs
{
    public class ChatHub : Hub<IChatHubClient>
    {
        public async Task Send(string data)
        {
            await Clients.All.Send(data);
        }
    }
}
