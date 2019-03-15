using System;
using System.Threading;

namespace SimulatedSensors.Contracts.SBGateway
{
    public enum PresenceSensorMode
    {
        Unoccupied,
        Present,
        RandomToggleOnly,
        Random
    }

    public class PresenceSensorAsset : IAsset
    {
        public string Id { get { return SensorId; } }

        public string DeviceId { get; set; }

        public string SensorId { get; set; }

        public PresenceSensorMode Mode { get; set; }

        public bool StateChanged { get; private set; } = false;

        private int sequenceNumber = 0;

        private bool currentPresence = false;
        public bool CurrentPresence
        {
            get
            {
                return currentPresence;
            }
            set
            {
                currentPresence = value;
                StateChanged = true;
            }
        }

        Random rnd = new Random();

        public SimulatorMessage GetMessage()
        {
            StateChanged = false;

            switch (Mode)
            {
                case PresenceSensorMode.Unoccupied:
                    CurrentPresence = false;
                    break;
                case PresenceSensorMode.Present:
                    CurrentPresence = true;
                    break;
                case PresenceSensorMode.RandomToggleOnly:
                    if ((rnd.NextDouble() >= 0.5) != CurrentPresence)
                    {
                        CurrentPresence = !CurrentPresence;
                    }
                    break;
                case PresenceSensorMode.Random:
                    CurrentPresence = (rnd.NextDouble() >= 0.5);
                    break;
            }

            var eventTime = DateTime.Now.ToString("M/d/yyyy h:m:s tt");
            var currentSequence = Interlocked.Increment(ref sequenceNumber);

            var message = new SimulatorMessage(new PresenceD2HMessage(this));
            message.D2CMessage.Properties.Add("MessageVersion", "1.0");
            message.D2CMessage.Properties.Add("ProductOrigin", "hawthorne");
            message.D2CMessage.Properties.Add("EventTime", eventTime);
            message.D2CMessage.Properties.Add("TransmitTime", eventTime);
            message.D2CMessage.Properties.Add("SequenceNumber", $"{currentSequence}");
            message.D2CMessage.Properties.Add("MessageType", "event");
            message.D2CMessage.Properties.Add("SensorId", SensorId);
            message.D2CMessage.Properties.Add("SignalType", "presence");
            message.D2CMessage.Properties.Add("IsInteractive", "true");

            return message;
        }
    }
}
