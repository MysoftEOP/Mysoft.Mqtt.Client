﻿using System;
using System.Collections.Generic;
using System.Text;
using Mysoft.Mqtt.Client.Extensions;

namespace Mysoft.Mqtt.Client.Topic
{
    public class MqttTopicBuilder
    {
        private ICollection<IMqttTopic> _topics;

        public MqttTopicBuilder()
        {
            _topics = new List<IMqttTopic>();
        }

        public MqttTopicBuilder With(IMqttTopic topic)
        {
            _topics.Add(topic);
            return this;
        }

        public MqttTopicBuilder With(string topic)
        {
            return With(new MqttTopic(topic));
        }

        public string Build(bool shared = false)
        {
            var tmp = _topics.Build();
            _topics.Clear();

            return shared ? $"$share/default/{tmp}" : tmp;
        }
    }
}
