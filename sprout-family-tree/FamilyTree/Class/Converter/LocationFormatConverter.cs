using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using FamilyTree.Domain.Model;

namespace FamilyTree.Class.Converter
{
    public class LocationFormatConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is LocationModel location)) return null;

            return $"{location.City}, {location.State} {location.Country}";
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