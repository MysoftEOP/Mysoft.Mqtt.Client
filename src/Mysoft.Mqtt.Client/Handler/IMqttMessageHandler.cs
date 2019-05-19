using Mysoft.Mqtt.Client.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mysoft.Mqtt.Client.Handler
{
    /// <summary>
    /// mqtt消息处理接口
    /// </summary>
    public interface IMqttMessageHandler
    {
        string[] Topic { get; }

        Task Execute(MqttMessage message);
    }
}
