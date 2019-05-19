﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Mysoft.Mqtt.Client.Message;
using Mysoft.Mqtt.Client.Topic;

namespace Mysoft.Mqtt.Client.Extensions
{
    public static class IMysoftMqttClientExtensions
    {
        public static void Publish(this IMysoftMqttClient client, params MqttMessageBuilder[] builders)
        {
            client.PublishAsync(builders).GetAwaiter().GetResult();
        }

        public static Task PublishAsync(this IMysoftMqttClient client, params MqttMessageBuilder[] builders)
        {
            return client.PublishAsync(builders.Select(x => x.Build()).ToArray());
        }

        public static Task PublishAsync(this IMysoftMqttClient client, params MqttMessage[] messages)
        {
            return Task.Factory.StartNew(async () =>
            {
                foreach (var message in messages)
                {
                    await client.PublishAsync(message);
                }
            });
        }

        public static void Publish(this IMysoftMqttClient client, params MqttMessage[] messages)
        {
            client.PublishAsync(messages).GetAwaiter().GetResult();
        }

        public static void Subscribe(this MysoftMqttClient client, IMqttTopic topic, MqttQosLevel qos)
        {
            client.Subscribe(topic.Build(), qos);
        }
    }
}
