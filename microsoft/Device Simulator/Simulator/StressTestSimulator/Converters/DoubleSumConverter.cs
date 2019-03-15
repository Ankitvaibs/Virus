using System;
using System.Globalization;
using System.Windows.Data;

namespace StressTestSimulator.Converters
{
    [ValueConversion(typeof(double), typeof(double))]
    public class DoubleSumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(double) || parameter.GetType() != typeof(double))
            {
                throw new ArgumentException();
            }

            return (double)value + (double)parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(double) || parameter.GetType() != typeof(double))
            {
                throw new ArgumentException();
            }

            return (double)value + (double)parameter;
        }
    }
}
