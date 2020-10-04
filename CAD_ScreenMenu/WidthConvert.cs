using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CAD屏幕菜单
{
	internal class WidthConvert : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return DependencyProperty.UnsetValue;
			}
			value = (double)value - 100.0;
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public WidthConvert()
		{
		}
	}
}
