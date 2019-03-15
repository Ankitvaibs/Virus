namespace SimulatedSensors.Contracts.SBGateway
{
    public class PresenceD2HMessage
    {
        public string DeviceId;

        public bool IsSimulatedDevice = true;

        public int Presence;

        public string SensorId;

        public PresenceD2HMessage(PresenceSensorAsset asset)
        {
            this.DeviceId = asset.DeviceId;
            this.SensorId = asset.SensorId;
            this.Presence = asset.CurrentPresence ? 1 : 0;
        }
    }
}
