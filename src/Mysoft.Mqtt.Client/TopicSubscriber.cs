using Mysoft.Mqtt.Client.Message;
using Mysoft.Mqtt.Client.Topic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mysoft.Mqtt.Client
{
    /// <summary>
    /// 主体订阅
    /// </summary>
    public sealed class TopicSubscriber : ITopicSubscriber
    {
        public TopicSubscriber(string topic, MqttQosLevel qos = MqttQosLevel.AtMostOnce, bool shared = false)
        {
            this.Topic = topic;
            this.Qos = qos;
            this.Shared = shared;
        }

        public TopicSubscriber(IMqttTopic topic, MqttQosLevel qos = MqttQosLevel.AtMostOnce, bool shared = false) : this(topic.Build(), qos, shared)
        {

        }

        /// <summary>
        /// 主题
        /// </summary>
        public string Topic { get; private set; }

        /// <summary>
        /// 质量等级
        /// </summary>
        public MqttQosLevel Qos { get; set; }

        /// <summary>
        /// 共享订阅
        /// </summary>
        public bool Shared { get; set; }
    }
}
