using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using SimulatedSensors.Contracts;

namespace SimulatedSensors
{
    public class DeviceSimulator
    {
        public bool SendingData { get; private set; }
        private Dictionary<string, IAsset> Assets = new Dictionary<string, IAsset>();
        private DeviceGateway _deviceGateway = new DeviceGateway();
        public int SendTelemetryFreq { get; set; } = 500;
        public bool Connected => _deviceGateway.Connected;

        // Event Handler for notifying the sent message state to the IoT Hub
        public event EventHandler SentMessageEventHandler;

        // Event Handler for notifying the reception of a new message from IoT Hub
        public event EventHandler ReceivedMessageEventHandler;

        public bool Pause()
        {
            return SendingData = false;
        }

        public bool Resume()
        {
            if (_deviceGateway.Connected)
            {
                return SendingData = true;
            }
            return false;
        }

        public void UpdateAsset(IAsset asset)
        {
            if (Assets.ContainsKey(asset.Id))
            {
                Assets[asset.Id] = asset;
            }
            else
            {
                Assets.Clear(); // ToDo: remove when UI will allow multiple sensors at the same time
                Assets.Add(asset.Id, asset);
            }
        }

        public bool Connect(string connectionString)
        {
            if (_deviceGateway.Connect(connectionString))
                SendMessages();
            return Connected;
        }

        public bool Disconnect()
        {
            return _deviceGateway.Disconnect();
        }

        public void EnqueMessage(Message msg)
        {
            _deviceGateway.EnqueMessage(msg);
        }

        private async void SendMessages()
        {
            while (Connected)
            {
                if (SendingData)
                    foreach (var asset in Assets.Values)
                    {
                        try
                        {
                            if (_deviceGateway.Connected)
                            {
                                var msg = asset.GetMessage();
                                if (asset.StateChanged)
                                {
                                    EnqueMessage(msg.D2CMessage);
                                    var logmsg = "Sent telemetry data to IoT Hub\n";

                                    SentMessageEventHandler?.Invoke(this, new ReceivedMessageEventArgs(
                                        new C2DMessage()
                                        {
                                            message = msg.JsonMessage,
                                            alerttype = "sent"
                                        }));
                                    Debug.WriteLine(logmsg);
                                }
                            }
                            else Debug.WriteLine("Connection To IoT Hub is not established. Cannot send message now");

                        }
                        catch (System.Exception e)
                        {
                            Debug.WriteLine("Exception while sending device telemetry data :\n" + e.Message.ToString(), "DE");
                            SentMessageEventHandler?.Invoke(this, new ReceivedMessageEventArgs(
                                   new C2DMessage()
                                   {
                                       message = "Exception while sending device telemetry data :\n" + e.Message.ToString(),
                                       alerttype = "Error"
                                   }));
                        }
                    }
                await Task.Delay(SendTelemetryFreq);
            }
        }
    }
}