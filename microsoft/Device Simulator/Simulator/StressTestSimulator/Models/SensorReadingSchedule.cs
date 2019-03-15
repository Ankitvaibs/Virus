using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StressTestSimulator.Models
{
    public class SensorReadingSchedule : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private TimeSpan _nextReadingIn;
        private TimeSpan _interval;

        public Sensor Sensor { get; }

        public TimeSpan NextReadingIn
        {
            get { return _nextReadingIn; }
            set
            {
                if (_nextReadingIn == value)
                {
                    return;
                }

                _nextReadingIn = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan Interval
        {
            get { return _interval; }
            set
            {
                if (_interval == value)
                {
                    return;
                }

                _interval = value;
                OnPropertyChanged();
            }
        }

        public SensorReadingSchedule(Sensor sensor)
        {
            Sensor = sensor;
        }



        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}