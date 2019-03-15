using System;
using System.Globalization;
using System.Windows.Data;

namespace StressTestSimulator.Converters
{
    [ValueConversion(typeof(bool), typeof(double))]
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(bool) || targetType != typeof(bool))
            {
                throw new ArgumentException();
            }

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(bool) || targetType != typeof(bool))
            {
                throw new ArgumentException();
            }

            return !(bool)value;
        }
    }
}