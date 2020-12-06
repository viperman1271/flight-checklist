using System;
using System.Globalization;
using Xamarin.Forms;

namespace FlightChecklist
{
    internal class LocalizationConverter : IValueConverter
    {
        public static readonly BindableProperty DataRepositoryProperty = BindableProperty.Create(nameof(DataRepository), typeof(MainModel), typeof(LocalizationConverter));

        public MainModel DataRepository { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(targetType == typeof(string) && value == null)
            {
                App.Log("", "MyApp", "Target type is string, but value is empty. Returning empty string");
                return string.Empty;
            }

            if (value is string && targetType == typeof(string))
            {
                return "Unknown";
            }
            else
            {
                return $"value is {value?.GetType()} and target type is {targetType}. Original value of value is {value}";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
