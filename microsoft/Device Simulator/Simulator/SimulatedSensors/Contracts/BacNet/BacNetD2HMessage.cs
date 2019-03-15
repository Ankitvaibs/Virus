using System;
using Newtonsoft.Json;

namespace SimulatedSensors.Contracts.BacNet
{
    public class BacNetD2HMessage
    {
        public BacNetD2HMessage(BacNetAsset asset)
        {
            this.Asset = asset;
            this.GatewayName = asset.GatewayId;
            this.Timestamp = DateTime.UtcNow.ToString("o");
        }

        [JsonProperty("GatewayName")]
        public string GatewayName;

        [JsonProperty("Timestamp")]
        public string Timestamp;

        [JsonProperty("Asset")]
        public BacNetAsset Asset;
    }
}
