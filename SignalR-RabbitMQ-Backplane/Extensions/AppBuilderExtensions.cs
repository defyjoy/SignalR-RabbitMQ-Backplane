﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SignalRRAbbitMQBackplane.RabbitMQServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRRAbbitMQBackplane.Extensions
{
    public static class AppBuilderExtensions
    {
        private static RabbitListener listener { get; set; }


        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            listener = app.ApplicationServices.GetService<RabbitListener>();

            var life = app.ApplicationServices.GetService<IApplicationLifetime>();

            //life.ApplicationStarted.Register(OnStarted);

            ////press Ctrl+C to reproduce if your app runs in Kestrel as a console app
            //life.ApplicationStopping.Register(OnStopping);

            return app;
        }

        //private static void OnStarted()
        //{
        //    listener.Register();
        //}

        //private static void OnStopping()
        //{
        //    listener.Deregister();
        //}
    }
}

