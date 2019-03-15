using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SimulatedSensors;
using SimulatedSensors.Contracts;
using SimulatedSensors.Data;
using StressTestSimulator.Models;
using StressTestSimulator.Properties;
using SimulatedSensors.Contracts.BacNet;

namespace StressTestSimulator.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Fields

        private DevicesProcessor _devicesProcessor;
        private Dictionary<string, DeviceGateway> _iotHubDeviceGateways;

        private string _dataBaseConnectionString = Settings.Default.DBConnectionString;
        private string _ioTHubConnectionString = Settings.Default.IoTHubConnectionString;

        private readonly Random _randomizer = new Random();

        private TimeSpan _minIntervalRandom = TimeSpan.FromMinutes(5);
        private TimeSpan _maxIntervalRandom = TimeSpan.FromMinutes(5);

        private bool _isConnected;
        private bool _isStarted;

        private double _minRandom = 40;
        private double _maxRandom = 60;

        private ObservableCollection<SensorReadingSchedule> _sensors;
        private SensorsReader _sensorsReader;

        private bool _isAdvancedMode;
        private bool _isConnecting;

        #endregion

        #region Properties

        public string DataBaseConnectionString
        {
            get { return _dataBaseConnectionString; }
            set
            {
                if (_dataBaseConnectionString == value)
                    return;

                _dataBaseConnectionString = value;

                Settings.Default.DBConnectionString = value;
                Settings.Default.Save();

                OnPropertyChanged();
            }
        }

        public string IoTHubConnectionString
        {
            get { return _ioTHubConnectionString; }
            set
            {
                if (_ioTHubConnectionString == value)
                    return;

                _ioTHubConnectionString = value;
                Settings.Default.IoTHubConnectionString = value;
                Settings.Default.Save();
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SensorReadingSchedule> Sensors
        {
            get { return _sensors; }
            set
            {
                if (_sensors == value)
                    return;

                _sensors = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DevicesGridVisibility));
            }
        }

        public bool IsToggleEnabledChecked
        {
            get { return Sensors?.All(s => s.Sensor.Enabled) ?? false; }
        }

        public bool IsStarted
        {
            get { return _isStarted; }
            set
            {
                if (_isStarted == value)
                {
                    return;
                }

                _isStarted = value;

                OnPropertyChanged();
            }
        }
        public bool IsAdvancedMode
        {
            get { return _isAdvancedMode; }
            set
            {
                if (_isAdvancedMode == value)
                {
                    return;
                }

                _isAdvancedMode = value;

                OnPropertyChanged();
            }
        }

        public double MinRandom
        {
            get { return _minRandom; }
            set
            {
                if (_minRandom.Equals(value))
                    return;

                _minRandom = Math.Round(value);
                OnPropertyChanged();
            }
        }

        public double MaxRandom
        {
            get { return _maxRandom; }
            set
            {
                if (_maxRandom.Equals(value))
                    return;

                _maxRandom = Math.Round(value);
                OnPropertyChanged();
            }
        }

        public Visibility DevicesGridVisibility
        {
            get { return Sensors?.Any() ?? false ? Visibility.Visible : Visibility.Collapsed; }
        }

        public TimeSpan MinIntervalRandom
        {
            get { return _minIntervalRandom; }
            set
            {
                if (_minIntervalRandom == value)
                    return;

                _minIntervalRandom = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan MaxIntervalRandom
        {
            get { return _maxIntervalRandom; }
            set
            {
                if (_maxIntervalRandom == value)
                    return;

                _maxIntervalRandom = value;
                OnPropertyChanged();
            }
        }

        public bool IsConnecting
        {
            get { return _isConnecting; }
            private set
            {
                if (_isConnecting == value)
                {
                    return;
                }

                _isConnecting = value;
                OnPropertyChanged();
            }
        }

        public bool IsConnected
        {
            get { return _isConnected; }
            private set
            {
                if (_isConnected == value)
                    return;

                _isConnected = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public IAsyncCommand ConnectCommand { get; private set; }

        public ICommand ToggleEnabledCommand { get; private set; }

        public ICommand ToggleVariableValueCommand { get; private set; }

        public ICommand RandomizeValuesCommand { get; private set; }

        public ICommand RandomizeReadInCommand { get; private set; }

        public ICommand ToggleStartCommand { get; private set; }

        public ICommand RandomizeIntervalsCommand { get; private set; }

        #endregion

        public MainWindowViewModel()
        {
            ConnectCommand = new DelegatedParameterlessAsyncCommand(Connect);
            ToggleEnabledCommand = new DelegatedCommand<bool>(ToggleEnabled);
            ToggleVariableValueCommand = new DelegatedCommand<bool>(ToggleVariableValue);
            RandomizeValuesCommand = new DelegatedParameterlessCommand(RandomizeValues);
            RandomizeReadInCommand = new DelegatedParameterlessCommand(RandomizeReadIn);
            RandomizeIntervalsCommand = new DelegatedParameterlessCommand(RandomizeIntervals);
            ToggleStartCommand = new DelegatedParameterlessCommand(ToggleStart);
        }

        private void ToggleVariableValue(bool state)
        {
            if (Sensors == null)
            {
                return;
            }

            foreach (var sensorReadingSchedule in Sensors)
            {
                sensorReadingSchedule.Sensor.IsVariableValueEnabled = state;
            }
        }

        private void ToggleStart()
        {
            if (!IsStarted)
            {
                _sensorsReader?.StopPolling();

                _sensorsReader = new SensorsReader(Sensors);
                _sensorsReader.OnSensorReading += _sensorsReader_OnSensorReading;
                _sensorsReader.StartPolling();
                IsStarted = true;

                return;
            }

            _sensorsReader?.StopPolling();
            IsStarted = false;
        }

        private void _sensorsReader_OnSensorReading(Sensor sensor)
        {
            if (sensor.IsVariableValueEnabled)
            {
                var sign = _randomizer.Next() % 2 == 0 ? 1 : -1;
                sensor.LastReadingValue = Math.Round(sensor.Value + sign * sensor.Value * _randomizer.NextDouble() / 10, 1);
            }
            else
            {
                sensor.LastReadingValue = sensor.Value;
            }

            if (!_iotHubDeviceGateways.ContainsKey(sensor.BACmap.GatewayName))
            {
                sensor.Enabled = false;
                sensor.ErrorMessage = $"'{sensor.BACmap.GatewayName}' gateway not found.";
                return;
            }

            try
            {
                var d2hMessage =
                    new BacNetD2HMessage(new BacNetAsset
                    {
                        DeviceId = sensor.BACmap.DeviceName,
                        GatewayId = sensor.BACmap.GatewayName,
                        ObjectType = sensor.BACmap.ObjectType,
                        Instance = sensor.BACmap.Instance,
                        Value = sensor.LastReadingValue
                    });
                var messages = new[] { d2hMessage };
                var msg = new Message(Serialize(messages));

                var deviceGateway = _iotHubDeviceGateways[sensor.BACmap.GatewayName];
                if (deviceGateway != null)
                {
                    if (!deviceGateway.Connected)
                    {
                        throw new Exception($"Device is disconnected from '{deviceGateway}' gateway");
                    }

                    deviceGateway.EnqueMessage(msg);

                }
            }
            catch (Exception e)
            {
                sensor.Enabled = false;
                sensor.ErrorMessage = e.Message;
            }
        }

        private byte[] Serialize(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(json);
        }


        private void RandomizeValues()
        {
            if (Sensors == null)
            {
                return;
            }

            foreach (var sensorReadingSchedule in Sensors)
            {
                sensorReadingSchedule.Sensor.Value = Math.Round(MinRandom + (MaxRandom - MinRandom) * _randomizer.NextDouble());
            }
        }

        private void RandomizeReadIn()
        {
            if (Sensors == null)
            {
                return;
            }

            foreach (var sensorReadingSchedule in Sensors)
            {
                sensorReadingSchedule.NextReadingIn = TimeSpan.FromSeconds(Math.Round(sensorReadingSchedule.Interval.TotalSeconds * _randomizer.NextDouble()));
            }
        }

        private void RandomizeIntervals()
        {
            if (Sensors == null)
            {
                return;
            }
            foreach (var sensorReadingSchedule in Sensors)
            {
                var randomInterval =
                    MinIntervalRandom.Add(
                        TimeSpan.FromSeconds(
                            Math.Round((MaxIntervalRandom - MinIntervalRandom).TotalSeconds * _randomizer.NextDouble())));
                sensorReadingSchedule.Interval = randomInterval;
            }
        }

        private void ToggleEnabled(bool state)
        {
            if (Sensors == null)
            {
                return;
            }
            foreach (var sensorReadingSchedule in Sensors)
            {
                sensorReadingSchedule.Sensor.Enabled = state;
            }
        }

        public async Task Connect()
        {
            IsConnecting = true;
            Disconnect();

            try
            {
                _devicesProcessor = new DevicesProcessor(IoTHubConnectionString, 1000, string.Empty);

                await Task.WhenAll(LoadSensorsDataAsync(), LoadIoTDevicesAsync());
                IsConnected = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Disconnect();
            }
            finally
            {
                IsConnecting = false;
            }
        }

        private async Task LoadIoTDevicesAsync()
        {
            _iotHubDeviceGateways = (await Task.Run(() => _devicesProcessor.GetDevices())).ToDictionary(i => i.Id, i =>
            {
                var gw = new DeviceGateway();
                gw.Connect(i.ConnectionString);
                return gw;
            });
        }

        private async Task LoadSensorsDataAsync()
        {
            Sensors = await Task.Run(() =>
               {
                   var dataContext = new SmartBuildingContext(DataBaseConnectionString);

                   return new ObservableCollection<SensorReadingSchedule>(
                       dataContext.BACmap.Select(m => new SensorReadingSchedule(new Sensor(m))));
               });

            RandomizeValues();
            RandomizeIntervals();
            RandomizeReadIn();
        }

        private void Disconnect()
        {
            IsConnected = false;

            _sensorsReader?.StopPolling();
            Sensors?.Clear();

            if (_iotHubDeviceGateways?.Values == null)
            {
                return;
            }

            foreach (var iotHubDeviceGateway in _iotHubDeviceGateways.Values)
            {
                iotHubDeviceGateway?.Disconnect();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}