using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace StressTestSimulator.Models
{
    public class SensorsReader
    {
        public IEnumerable<SensorReadingSchedule> SensorsSchedule { get; private set; }
        private Timer _timer;

        public event Action<Sensor> OnSensorReading;

        public SensorsReader(IEnumerable<SensorReadingSchedule> sensorReadingSchedules)
        {
            SensorsSchedule = sensorReadingSchedules;
        }

        public void StartPolling()
        {
            _timer = new Timer(Tick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        public void StopPolling()
        {
            _timer.Dispose();
        }

        public void Tick(object state)
        {
            foreach (var sensorReadingSchedule in SensorsSchedule.Where(s => s.Sensor.Enabled))
            {
                sensorReadingSchedule.NextReadingIn = sensorReadingSchedule.NextReadingIn.Subtract(TimeSpan.FromSeconds(1));

                if (sensorReadingSchedule.NextReadingIn <= TimeSpan.Zero)
                {
                    sensorReadingSchedule.NextReadingIn = sensorReadingSchedule.Interval;
                    OnSensorReading?.Invoke(sensorReadingSchedule.Sensor);
                }
            }
        }
    }
}