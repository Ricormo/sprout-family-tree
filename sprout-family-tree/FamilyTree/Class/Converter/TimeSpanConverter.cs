using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace FamilyTree.Class.Converter
{
    public class TimeSpanConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var start = GetFormattedDate(values[0]);
            var end = GetFormattedDate(values[1]);

            if (!string.IsNullOrWhiteSpace(end)) 
                end = " - " + end;

            return start + end;
        }

        private static string GetFormattedDate(object value)
        {
            if (value == null || !DateTime.TryParse(value.ToString(), out var date))
                return "";
            return $"{date:MM/dd/yyyy}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}