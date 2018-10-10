using System;
using System.Globalization;

namespace Mailie.ValueConverters
{
  public class EllipsisValueConverter : ValueConverterBase
  {
    public int MaxCharacters { get; set; } = 50;

    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null)
        return null;

      return value.ToString().Substring(0, MaxCharacters) + "...";
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotSupportedException();
    }
  }
}