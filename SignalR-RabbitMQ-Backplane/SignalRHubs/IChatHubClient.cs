using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRRAbbitMQBackplane.SignalRHubs
{
    public interface IChatHubClient
    {
        Task Send(string data);
    }
}
