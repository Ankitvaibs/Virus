using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace SimulatedSensors.Contracts.BacNet
{
    public class BacNetAsset : IAsset
    {
        [JsonIgnore]
        public string GatewayId { get; set; }

        [JsonIgnore]
        public bool Variation;

        [JsonProperty("DeviceName")]
        public string DeviceId { get; set; }

        [JsonProperty("ObjectType")]
        public string ObjectType;

        [JsonProperty("Instance", 
            DefaultValueHandling = DefaultValueHandling.Ignore, 
            NullValueHandling = NullValueHandling.Ignore
            ),DefaultValue("")]
        public string Instance;

        [JsonProperty("PresentValue")]
        public double Value;

        [JsonProperty("IsSimulatedDevice")]
        public bool IsSimulatedDevice = true;

        Random rnd = new Random();

        public string Id
        {
            get
            {
                return GatewayId + DeviceId;
            }
        }

        public bool StateChanged { get; } = true;

        public SimulatorMessage GetMessage()
        {
            var d2hMessage = new BacNetD2HMessage(this);
            double variation = 0.0;
            if (d2hMessage.Asset.Variation)
            {
                variation = rnd.Next(-10, 11) / 10.0;
                d2hMessage.Asset.Value += variation;
            }

            var d2hMessages = new BacNetD2HMessage[] { d2hMessage };
            var msg = new SimulatorMessage(d2hMessages);

            Value -= variation;

            return msg;
        }
    }
}
