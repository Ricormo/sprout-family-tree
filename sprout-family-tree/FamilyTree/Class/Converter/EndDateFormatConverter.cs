using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace FamilyTree.Class.Converter
{
    class EndDateFormatConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !DateTime.TryParse(value.ToString(), out DateTime date))
                return "";
            return $" - {date.ToString("MM/dd/yyyy")}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}