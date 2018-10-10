using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mailie.ValueConverters
{
  public abstract class ValueConverterBase : IMarkupExtension, IValueConverter
  {
    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
    public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

    public object ProvideValue(IServiceProvider serviceProvider)
    {
      return this;
    }
  }
}