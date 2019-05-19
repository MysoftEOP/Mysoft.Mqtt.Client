using System;
using System.Collections.Generic;
using System.Text;

namespace Mysoft.Mqtt.Client.Topic
{
    public class MqttTopic : IMqttTopic
    {
        private readonly string _topic;

        public MqttTopic(string topic)
        {
            _topic = topic;
        }

        public string Build()
        {
            return _topic;
        }
    }
}
