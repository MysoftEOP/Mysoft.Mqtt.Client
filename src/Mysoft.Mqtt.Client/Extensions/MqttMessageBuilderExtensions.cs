using Mysoft.Mqtt.Client.Message;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mysoft.Mqtt.Client.Extensions
{
    public static class MqttMessageBuilderExtensions
    {
        public static MqttMessageBuilder WithPayload<T>(this MqttMessageBuilder builder, T obj) where T : class
        {
            return builder.WithPayload(JsonConvert.SerializeObject(obj));
        }
    }
}
