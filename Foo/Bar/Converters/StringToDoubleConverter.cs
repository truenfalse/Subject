using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Bar.Converters
{
    [ValueConversion(typeof(string), typeof(double))]
    public class StringToDoubleConverter : IValueConverter
    {
        public static StringToDoubleConverter Instance = new StringToDoubleConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double val = double.Parse(value.ToString());
                return val;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
