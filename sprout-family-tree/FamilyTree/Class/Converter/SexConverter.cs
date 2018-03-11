using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace FamilyTree.Class.Converter
{
    public class SexConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";
            bool.TryParse(value.ToString(), out var sex);
            return sex ? "♂" : "♀";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.ToString() == "♂";
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}