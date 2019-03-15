using System.Text;

using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

namespace SimulatedSensors.Contracts
{
    public class SimulatorMessage
    {
        public Message D2CMessage { get; private set; }

        public string JsonMessage { get; private set; }

        public SimulatorMessage(object messages)
        {
            JsonMessage = JsonConvert.SerializeObject(messages);
            D2CMessage = new Message(Serialize(messages));
        }

        /// <summary>
        /// Serialize message
        /// </summary>
        private byte[] Serialize(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
