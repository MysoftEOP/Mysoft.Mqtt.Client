using Mysoft.Mqtt.Client.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mysoft.Mqtt.Client.Message
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class MqttMessage : MqttDeformMessage, IMqttPayload<byte[]>
    {
        /// <summary>
        /// 消息体
        /// </summary>
        [JsonProperty("payload")]
        public byte[] Payload { get; set; }

        public override string ToString()
        {
            return $"topic:{Topic}{Environment.NewLine}payload:{this.ConvertPayloadToString()}";
        }
    }
}
