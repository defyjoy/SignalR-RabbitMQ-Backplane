using EasyNetQ;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SignalRRAbbitMQBackplane.SignalRHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRRAbbitMQBackplane.RabbitMQServices
{
    public class RabbitListener
    {
        /// <summary>
        /// constants
        /// </summary>
        private const string TOPIC = "chat";

        /// <summary>
        /// DI members
        /// </summary>
        private readonly IBus bus;
        private readonly IHubContext<ChatHub,IChatHubClient> hubContext;
        
        public RabbitListener(IBus bus, IHubContext<ChatHub, IChatHubClient> hubContext)
        {
            this.hubContext = hubContext;
            bus.Subscribe<string>(TOPIC, HandleHeads, config => config.WithTopic(TOPIC));
        }

        private void HandleHeads(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Received {message} from {TOPIC}.");
            Console.ResetColor();
            hubContext.Clients.All.Send(message);
        }
    }
}
