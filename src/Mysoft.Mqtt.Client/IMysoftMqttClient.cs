using Mysoft.Mqtt.Client.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mysoft.Mqtt.Client
{
    public interface IMysoftMqttClient : IDisposable
    {
        event EventHandler<MqttMessage> MessageReceived;

        void Publish(MqttMessage message);

        Task PublishAsync(MqttMessage message);

        /// <summary>
        /// 清空订阅
        /// </summary>
        /// <returns></returns>
        void Flush();
    }
}
