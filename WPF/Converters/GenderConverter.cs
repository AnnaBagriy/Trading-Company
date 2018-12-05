using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF.Converters
{
    internal class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gender = (bool?)value;

            if (gender == false)
            {
                return "Female";
            }
            else if (gender == true)
            {
                return "Male";
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
