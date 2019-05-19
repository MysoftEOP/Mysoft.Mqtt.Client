using System;
using System.Linq;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Mysoft.Mqtt.Client;
using Mysoft.Mqtt.Client.Extensions;
using Mysoft.Mqtt.Client.Handler;
using Mysoft.Mqtt.Client.Message;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MysoftMqttServiceCollectionExtensions
    {
        public static IServiceCollection AddMqttClient(this IServiceCollection services, string clientId, string host, int? port = null, bool cleanSession = true, params TopicSubscriber[] topics)
        {
            services
                .AddMqttClient(new MqttClientOptions()
                {
                    Host = host,
                    Port = port ?? 1883,
                    CleanSession = cleanSession,
                    ClientId = clientId,
                    KeepAlivePeriod = TimeSpan.FromSeconds(15),
                    WillMessage = new MqttMessageBuilder()
                        .WithTopic(new ClientStatusTopic(clientId))
                        .WithPayload(ClientStatusModel.Create(clientId, false))
                        .WithRetainFlag(!cleanSession)
                        .Build(),
                    Subscribers = topics ?? new TopicSubscriber[] { },
                    SharpLimit = false
                })
                ;

            return services;
        }

        public static IServiceCollection AddMqttClient(this IServiceCollection services, MqttClientOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if (options.SharpLimit && options.Subscribers.Any(x => x.Topic?.Contains("#") == true))
            {
                throw new ArgumentException("不能以通配符'#'订阅任何主题");
            }

            if (options.WillMessage == null)
            {
                options.WillMessage = new MqttMessageBuilder()
                    .WithTopic(new ClientStatusTopic(options.ClientId))
                    .WithPayload(ClientStatusModel.Create(options.ClientId, false))
                    .WithRetainFlag(!options.CleanSession)
                    .Build();
            }

            services
                .AddSingleton<IMqttClientOptions>(options)
                .AddM2MqttClient();
            //.AddMqttnetClient(clientId, host, port, cleanSession)

            return services;
        }

        public static IServiceCollection AddMqttHandler<THandler>(this IServiceCollection services) where THandler : class, IMqttMessageHandler
        {
            services
                .AddTransient<IMqttMessageHandler, THandler>();

            return services;
        }

        //public static IServiceCollection AddMqttSubscriber(this IServiceCollection services, TopicSubscriber subscriber)
        //{
        //    services
        //        .AddSingleton()

        //    return services;
        //}


        //public static IServiceCollection AddMqttSubscriber(this IServiceCollection services, string topic, MqttQosLevel qos = MqttQosLevel.AtMostOnce, bool share = false)
        //{
        //    return services.AddMqttSubscriber(new TopicSubscriber(topic, qos, share));
        //}

        #region M2Mqtt
        private static IServiceCollection AddM2MqttClient(this IServiceCollection services)
        {
            services
                .AddSingleton<IMysoftMqttClient, M2MqttClient>()
                ;

            return services;
        }
        #endregion
    }
}
