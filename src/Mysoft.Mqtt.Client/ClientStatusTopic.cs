using Mysoft.Mqtt.Client.Topic;

namespace Mysoft.Mqtt.Client
{
    internal class ClientStatusTopic : IMqttTopic
    {
        private readonly string clientId;

        public ClientStatusTopic(string clientId)
        {
            this.clientId = clientId;
        }

        public string Build()
        {
            return $"clients/{clientId}/status";
        }
    }
}