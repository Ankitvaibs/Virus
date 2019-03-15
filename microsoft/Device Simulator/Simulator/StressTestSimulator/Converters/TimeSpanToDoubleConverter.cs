using System;
using System.Globalization;
using System.Windows.Data;

namespace StressTestSimulator.Converters
{
    [ValueConversion(typeof(TimeSpan), typeof(double))]
    public class TimeSpanToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(TimeSpan) || targetType != typeof(double))
            {
                throw new ArgumentException();
            }

            return ((TimeSpan)value).TotalSeconds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(double) ||  targetType != typeof(TimeSpan))
            {
                throw new ArgumentException();
            }

            return TimeSpan.FromSeconds((int)(double)value);
        }
    }
}
