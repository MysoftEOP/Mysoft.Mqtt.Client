using Mysoft.Mqtt.Client.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mysoft.Mqtt.Client
{
    public interface IMqttClientOptions
    {
        string Host { get; set; }

        int Port { get; set; }

        string ClientId { get; }

        bool CleanSession { get; }

        TimeSpan KeepAlivePeriod { get; }

        TimeSpan AutoReconnectedDelay { get; }

        MqttMessage WillMessage { get; }

        TopicSubscriber[] Subscribers { get; }

        bool SharpLimit { get; }
    }
}
