using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRRAbbitMQBackplane.SignalRHubs;

namespace SignalRRAbbitMQBackplane.Controllers
{
    //[Produces("application/json")]
    [Route("api/Chat")]
    public class ChatController : Controller
    {
        private readonly IBus bus;
        private readonly IHubContext<ChatHub,IChatHubClient> hubContext;

        public ChatController(IBus bus,IHubContext<ChatHub,IChatHubClient> hubContext)
        {
            this.hubContext = hubContext;
            this.bus = bus;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> Send([FromBody]string message)
        {
            await bus.PublishAsync(message,"chat");
            return Ok();
        }
    }
}