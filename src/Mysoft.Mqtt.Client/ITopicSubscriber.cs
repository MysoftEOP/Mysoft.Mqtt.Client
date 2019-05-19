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
    public interface ITopicSubscriber
    {
        /// <summary>
        /// 主题
        /// </summary>
        string Topic { get; }

        /// <summary>
        /// 质量等级
        /// </summary>
        MqttQosLevel Qos { get; }

        /// <summary>
        /// 共享订阅
        /// </summary>
        bool Shared { get; }
    }
}
