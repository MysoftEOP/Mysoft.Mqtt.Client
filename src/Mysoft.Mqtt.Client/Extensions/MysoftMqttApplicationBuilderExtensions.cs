using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mysoft.Mqtt.Client.Extensions
{
    public static class MysoftMqttApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMqttClient(this IApplicationBuilder app)
        {
            //激活客户端
            var client = app.ApplicationServices.GetService<IMysoftMqttClient>();

            var lifetime = app.ApplicationServices.GetService<IApplicationLifetime>();

            var cancellationToken = lifetime.ApplicationStopping;
            cancellationToken.Register(() =>
            {
                client.Dispose();
            });

            return app;
        }
    }
}
