using Mysoft.Mqtt.Client.Message;
using Mysoft.Mqtt.Client.Topic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Mysoft.Mqtt.Client.Handler
{
    /// <summary>
    /// mqtt消息处理基础类
    /// 所有需要处理的mqtt消息需继承自该类
    /// </summary>
    public abstract class MqttMessageHandler : IMqttMessageHandler
    {
        /// <summary>
        /// 主题
        /// </summary>
        public string[] Topic => MqttTopic?.Select(x => x.Build()).ToArray();

        /// <summary>
        /// 主题对象
        /// </summary>
        protected abstract IMqttTopic[] MqttTopic { get; }

        /// <summary>
        /// 消息执行
        /// </summary>
        /// <param name="message"></param>
        public abstract Task Execute(MqttMessage message);
    }
}
