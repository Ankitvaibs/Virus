using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SimulatedSensors.Contracts;

namespace SimulatedSensors
{
    public class DeviceGateway
    {
        public int SendTelemetryFreq { get; set; } = 100;

        private DeviceClient _deviceClient;
        private Queue<Message> _messages = new Queue<Message>();

        // Sending and receiving tasks
        CancellationTokenSource _tokenSource = new CancellationTokenSource();

        // Event Handler for notifying the reception of a new message from IoT Hub
        public event EventHandler ReceivedMessageEventHandler;
        public bool Connected { get; protected set; }

        protected CancellationToken ct;
        private bool cancelledSender = true, cancelledReceiver = true;

        // Trigger for notifying reception of new message from Connect The Dots dashboard
        protected virtual void OnReceivedMessage(ReceivedMessageEventArgs e)
        {
            ReceivedMessageEventHandler?.Invoke(this, e);
        }

        public bool Connect(string connectionString)
        {
            try
            {
                if (Connected)
                    Disconnect();
                while (!cancelledReceiver || !cancelledReceiver)
                {
                    Thread.Sleep(SendTelemetryFreq);
                }
                // Create Azure IoT Hub Client and open messaging channel
                _deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Http1);
                _deviceClient.OpenAsync();
                Connected = true;

                // Create send and receive tasks
                CancellationToken ct = _tokenSource.Token;
                Task.Factory.StartNew(async () => {
                    while (Connected)
                    {
                        await SendData();
                        await Task.Delay(SendTelemetryFreq);

                        if (ct.IsCancellationRequested)
                        {
                            // Cancel was called
                            Debug.WriteLine("Sending task canceled");
                            cancelledSender = true;
                            break;
                        }

                    }
                }, ct);

                Task.Factory.StartNew(async () =>
                {
                    while (Connected)
                    {
                        // Receive message from Cloud (for now this is a pull because only HTTP is available for UWP applications)
                        Message message = await _deviceClient.ReceiveAsync();
                        if (message != null)
                        {
                            try
                            {
                                // Read message and deserialize
                                C2DMessage command = DeSerialize(message.GetBytes());

                                // Invoke message received callback
                                OnReceivedMessage(new ReceivedMessageEventArgs(command));

                                // We received the message, indicate IoTHub we treated it
                                await _deviceClient.CompleteAsync(message);
                            }
                            catch (Exception e)
                            {
                                // Something went wrong. Indicate the backend that we coudn't accept the message
                                await _deviceClient.RejectAsync(message);
                            }
                        }
                        if (ct.IsCancellationRequested)
                        {
                            // Cancel was called
                            Debug.WriteLine("Receiving task canceled", "DE");
                            cancelledReceiver = true;
                            break;
                        }
                    }
                }, ct);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error while trying to connect to IoT Hub: " + e.Message, "DE");
                _deviceClient = null;
                return false;
            }
            return true;
        }

        private async Task SendData()
        {
            Message msg;
            while (_messages.Count > 0)
            {
                msg = _messages.Dequeue();
                await _deviceClient.SendEventAsync(msg);
            }
        }

        public bool Disconnect()
        {
            if (_deviceClient != null)
            {
                try
                {
                    _tokenSource.Cancel();
                    _deviceClient.CloseAsync();
                    _deviceClient = null;
                    Connected = false;
                }
                catch
                {
                    Debug.WriteLine("Error while trying close the IoT Hub connection");
                    return false;
                }
            }
            return true;
        }

        public void EnqueMessage(Message msg)
        {
            _messages.Enqueue(msg);
        }

        /// <summary>
        /// DeSerialize message
        /// </summary>
        private C2DMessage DeSerialize(byte[] data)
        {
            string text = Encoding.UTF8.GetString(data, 0, data.Length);
            return JsonConvert.DeserializeObject<C2DMessage>(text);
        }
    }
}