using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Dapper;
using SimulatedSensors.Contracts;
using Timer = System.Windows.Forms.Timer;
using SimulatedSensors.Contracts.BacNet;
using SimulatedSensors.Contracts.SBGateway;

namespace SimulatedSensors.Windows
{
    public partial class MainForm : Form
    {
        DeviceSimulator DeviceInstance = new DeviceSimulator();
        Dictionary<string, DeviceEntity> Devices = new Dictionary<string, DeviceEntity>();

        List<GroupBox> deviceGroupBoxes = new List<GroupBox>();

        private DeviceEntity SelectedDevice;

        private List<BACmap> RefData = new List<BACmap>();

        private delegate void AppendAlert(string AlertText);

        private StringBuilder errorsList = new StringBuilder();
        private int SentMessagesCount = 0;

        public string SelectedGatewayId => cmbGatewayId.Text;

        public string SelectedHubDeviceId => cmbHubDevices.SelectedValue.ToString();

        public string SelectedDeviceId => cmbDeviceId.SelectedItem.ToString();

        public string SelectedObjectType => cmbObjectType.Text;

        private string dbcs
        {
            get
            {
                if (!string.IsNullOrEmpty(textDBConnectionString.Text))
                    return textDBConnectionString.Text;
                if (ConfigurationManager.ConnectionStrings["RefData"] != null)
                    return ConfigurationManager.ConnectionStrings["RefData"].ConnectionString;
                else return string.Empty;
            }
        }

        class DeviceTypeListEntry
        {
            public DeviceTypes DeviceType { get; set; }
            public string Description { get; set; }
        }

        class PresenceModeListEntry
        {
            public PresenceSensorMode Mode { get; set; }
            public string Description { get; set; }
        }

        public MainForm()
        {
            InitializeComponent();

            buttonSend.Enabled = false;

            textConnectionString.TextChanged += TextConnectionString_TextChanged;
            textConnectionString.Text = Properties.Settings.Default.IoTHubConnectionString;

            trackBarTemperature.ValueChanged += TrackBarTemperature_ValueChanged;

            TrackBarTemperature_ValueChanged(null, null);

            deviceGroupBoxes.Insert((int)DeviceTypes.BacNet, bacnetControls);
            deviceGroupBoxes.Insert((int)DeviceTypes.SBPresence, sbControls);

            deviceTypes.DataSource = new DeviceTypeListEntry[] {
                new DeviceTypeListEntry { DeviceType = DeviceTypes.BacNet, Description = "BacNet" },
                new DeviceTypeListEntry { DeviceType = DeviceTypes.SBPresence, Description = "SmartBuildings Presence Sensor" },
            };

            deviceTypes.DisplayMember = "Description";
            deviceTypes.ValueMember = "DeviceType";

            presence.DataSource = new PresenceModeListEntry[] {
                new PresenceModeListEntry { Mode = PresenceSensorMode.Unoccupied, Description = "Not present" },
                new PresenceModeListEntry { Mode = PresenceSensorMode.Present, Description = "Present" },
                new PresenceModeListEntry { Mode = PresenceSensorMode.RandomToggleOnly, Description = "Random / send only state changes" },
                new PresenceModeListEntry { Mode = PresenceSensorMode.Random, Description = "Random" }
            };

            presence.DisplayMember = "Description";
            presence.ValueMember = "Mode";

        }

        private void DeviceInstance_SentMessageEventHandlerBacNet(object sender, EventArgs e)
        {
            C2DMessage message = ((ReceivedMessageEventArgs)e).Message;
            if (sendFrequency.Value >= 1000 || SentMessagesCount % 10 == 0 || message.alerttype.ToLower() == "error")
            {
                if (message.alerttype.ToLower() == "error")
                    errorsList.AppendLine(message.message);
                this.BeginInvoke(new AppendAlert(Target), message.alerttype + " - " + message.message);
            }

            SentMessagesCount++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (1000);
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void DeviceInstanceReceivedMessage(object sender, EventArgs e)
        {
            C2DMessage message = ((ReceivedMessageEventArgs)e).Message;
            var textToDisplay = message.timecreated + " - Alert received:" + message.message + ": " + message.value + " " + message.unitofmeasure;
            this.BeginInvoke(new AppendAlert(Target), textToDisplay);
        }

        private void Target(string text)
        {
            if (textAlerts.Text.Length > 4096)
                textAlerts.Clear();

            textAlerts.AppendText(text + "\r\n");
        }

        private void TrackBarTemperature_ValueChanged(object sender, EventArgs e)
        {
            labelTemperature.Text = "Value: " + trackBarTemperature.Value;
            UpdateAsset();
        }

        private void UpdateAsset()
        {
            if (DeviceInstance.Connected)
            {
                IAsset asset = null;
                switch((DeviceTypes)deviceTypes.SelectedIndex)
                {
                    case DeviceTypes.BacNet:
                        asset = new BacNetAsset
                        {
                            DeviceId = cmbDeviceId.Text,
                            GatewayId = cmbGatewayId.Text,
                            ObjectType = cmbObjectType.Text,
                            Instance = cmbInstance.Text,
                            Value = trackBarTemperature.Value,
                            Variation = checkBoxVariation.Checked
                        };
                        break;

                    case DeviceTypes.SBPresence:
                        asset = new PresenceSensorAsset
                        {
                            DeviceId = deviceId.Text,
                            SensorId = sensorId.Text,
                            Mode = (PresenceSensorMode)presence.SelectedValue
                        };
                        break;
                }

                DeviceInstance.UpdateAsset(asset);
            }
        }

        private void TextConnectionString_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["IoTHubConnectionString"] = textConnectionString.Text;
            Properties.Settings.Default.Save();
        }

        private bool CheckConfig(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                // ToDo: Add validation here
                return true;
            }

            return false;
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            ToggleSendingData();
        }

        private void ToggleSendingData()
        {
            if (DeviceInstance.SendingData)
            {
                DeviceInstance.Pause();
                btnGetDevices.Enabled =
                cmbHubDevices.Enabled =
                cmbGatewayId.Enabled =
                cmbDeviceId.Enabled =
                cmbObjectType.Enabled =
                deviceId.Enabled =
                sensorId.Enabled =
                presence.Enabled =
                checkBoxVariation.Enabled = true;
                buttonSend.Text = "Press to send telemetry data";
            }
            else
            {
                if (CheckConfig(textConnectionString.Text))
                {
                    if (DeviceInstance.Connected)
                        DeviceInstance.Resume();

                    UpdateAsset();

                    btnGetDevices.Enabled =
                    cmbHubDevices.Enabled =
                    cmbGatewayId.Enabled =
                    cmbDeviceId.Enabled =
                    cmbObjectType.Enabled =
                    deviceId.Enabled =
                    sensorId.Enabled =
                    presence.Enabled =
                    checkBoxVariation.Enabled = false;

                    buttonSend.Text = "Sending telemetry data";
                }
            }
        }

        private async void btnGetDevices_Click(object sender, EventArgs e)
        {
            try
            {
                btnGetDevices.Enabled = false;
                await GetDevices(textConnectionString.Text);
            }
            catch (Exception ex)
            {
                Target(ex.Message);
            }
            finally
            {
                btnGetDevices.Enabled = true;
            }
        }

        public async Task GetDevices(string connectionString)
        {
            try
            {
                var devicesProcessor = new DevicesProcessor(connectionString, 1000, string.Empty);
                var devices = await devicesProcessor.GetDevices();

                Devices.Clear();

                foreach (var device in devices)
                {
                    Devices.Add(device.Id, device);
                }
                cmbHubDevices.DataSource = Devices.Keys.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid IoTHub connection string. " + ex.Message);
            }
        }


        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((SelectedDevice == null) || (Devices.ContainsKey(SelectedHubDeviceId) && SelectedDevice.Id != SelectedHubDeviceId))
            {
                if (DeviceInstance.Connected)
                {
                    if (DeviceInstance.Disconnect())
                    {
                        buttonSend.Enabled = false;
                    }
                }

                // Initialize IoT Hub client
                DeviceInstance = new DeviceSimulator();

                // Attach receive callback for alerts
                DeviceInstance.ReceivedMessageEventHandler += DeviceInstanceReceivedMessage;
                DeviceInstance.SentMessageEventHandler += DeviceInstance_SentMessageEventHandlerBacNet;

                SelectedDevice = Devices[SelectedHubDeviceId];
                Connect(SelectedDevice.ConnectionString);
            }
            else
            {
                buttonSend.Enabled = true;
            }
        }

        private void Connect(string deviceConnectionString)
        {
            if (DeviceInstance.Connect(deviceConnectionString))
            {
                buttonSend.Enabled = true;
            }

            if (!string.IsNullOrEmpty(dbcs))
            {
                RefData = GetData(dbcs);
                var gateways = RefData.Select(d => d.GatewayName).Distinct().ToList();
                cmbGatewayId.DataSource = gateways;
            }
        }

        public List<BACmap> GetData(string connectionString)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<BACmap>("SELECT * FROM BACmap").ToList();
            }
        }


        private void cmbGatewayId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedGatewayId))
            {
                cmbDeviceId.DataSource = null;
                return;
            }

            var devices = RefData.Where(i => i.GatewayName == SelectedGatewayId).Select(d => d.DeviceName).Distinct().ToList();
            cmbDeviceId.DataSource = devices.Count > 0 ? devices : null;
        }


        private void cmbDeviceId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedGatewayId) || string.IsNullOrEmpty(SelectedGatewayId))
            {
                cmbObjectType.DataSource = null;
                return;
            }

            var oti =
                RefData.Where(i => i.GatewayName == SelectedGatewayId && i.DeviceName == SelectedDeviceId)
                    .Select(d => d.ObjectType)
                    .Distinct()
                    .ToList();

            cmbObjectType.DataSource = oti.Count > 0 ? oti : null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DeviceInstance.Connected && DeviceInstance.SendingData)
            {
                lblSentCount.Text = "(" + SentMessagesCount + ")";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E && errorsList.Length > 0)
            {
                textAlerts.Clear();
                textAlerts.Text = errorsList.ToString();
            }
        }

        private void cmbObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedGatewayId) || string.IsNullOrEmpty(SelectedGatewayId) || string.IsNullOrEmpty(SelectedObjectType))
            {
                cmbInstance.DataSource = null;
                return;
            }

            var data =
                RefData.Where(i => i.GatewayName == SelectedGatewayId && i.DeviceName == SelectedDeviceId && i.ObjectType == SelectedObjectType)
                    .Select(d => d.Instance)
                    .Distinct()
                    .OrderBy(value=>value)
                    .ToList();

            cmbInstance.DataSource = data.Count > 0 ? data : null;
        }

        private void deviceTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int index = 0; index < deviceGroupBoxes.Count; index++)
            {
                deviceGroupBoxes[index].Visible = (index == deviceTypes.SelectedIndex);
            }
        }

        private void sendFrequency_ValueChanged(object sender, EventArgs e)
        {
            DeviceInstance.SendTelemetryFreq = (int)sendFrequency.Value;
        }
    }
}
