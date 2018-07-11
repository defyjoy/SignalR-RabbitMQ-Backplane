using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SignalRRAbbitMQBackplane
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            ConfigureRabbitMQ();
        }

        private static void ConfigureRabbitMQ()
        {
            var bus = RabbitHutch.CreateBus("host=localhost");
            bus.SubscribeAsync<string>("chat", message => Task.Run(() => Console.WriteLine(message)));
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
