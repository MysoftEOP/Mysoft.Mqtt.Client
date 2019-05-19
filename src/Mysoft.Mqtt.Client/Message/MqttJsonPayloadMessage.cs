using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mysoft.Mqtt.Client.Message
{
    [Serializable]
    public class MqttJsonPayloadMessage : MqttDeformMessage, IMqttPayload<string>
    {
        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}
