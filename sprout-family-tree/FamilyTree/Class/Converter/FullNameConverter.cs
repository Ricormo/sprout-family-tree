using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace FamilyTree.Class.Converter
{
    public class FullNameConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return 
                (string.IsNullOrWhiteSpace(values[0]?.ToString()) 
                    ? " " 
                    : values[0] + " ") 
                + values[1];
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