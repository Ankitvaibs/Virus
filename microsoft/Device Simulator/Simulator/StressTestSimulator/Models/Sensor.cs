using System.ComponentModel;
using System.Runtime.CompilerServices;
using SimulatedSensors.Data;

namespace StressTestSimulator.Models
{
    public class Sensor : INotifyPropertyChanged
    {
        private double _value;
        private bool _enabled = true;
        private string _errorMessage;
        private bool _isVariableValueEnabled = true;
        private double _lastReadingValue;

        public BACmap BACmap { get; }

        public string FullAssetPath { get; }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled == value)
                {
                    return;
                }

                _enabled = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage == value)
                {
                    return;
                }

                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value.Equals(value))
                {
                    return;
                }

                _value = value;
                OnPropertyChanged();
            }
        }

        public bool IsVariableValueEnabled
        {
            get { return _isVariableValueEnabled; }
            set
            {
                if (_isVariableValueEnabled == value)
                {
                    return;
                }

                _isVariableValueEnabled = value;
                OnPropertyChanged();
            }
        }

        public double LastReadingValue
        {
            get { return _lastReadingValue; }
            set
            {
                if (_lastReadingValue.Equals(value))
                {
                    return;
                }

                _lastReadingValue = value;
                OnPropertyChanged();
            }
        }

        public Sensor(BACmap bacMap)
        {
            BACmap = bacMap;
            FullAssetPath = string.Join("/", bacMap.Region, bacMap.Campus, bacMap.Building, bacMap.EquipmentClass, bacMap.Floor, bacMap.Unit);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
