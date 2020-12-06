using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace FlightChecklist
{
    internal class LocalizationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(targetType == typeof(string) && value == null)
            {
                App.Log("", "MyApp", "Target type is string, but value is empty. Returning empty string");
                return string.Empty;
            }

            if (value is string && targetType == typeof(string))
            {
                ObjectModel.Identifier identifier = App.DataRepository.Identifiers.FirstOrDefault(o => o.Name == (string)value);
                if (identifier != null)
                {
                    return identifier.Value;
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
