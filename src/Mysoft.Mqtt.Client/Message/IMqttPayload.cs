using System;
using System.Collections.Generic;
using System.Text;

namespace Mysoft.Mqtt.Client.Message
{
    /// <summary>
    /// mqtt消息体结构定义接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMqttPayload<T>
    {
        /// <summary>
        /// 消息体
        /// </summary>
        T Payload { get; set; }
    }
}
