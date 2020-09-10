using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Bar.Converters
{
    [ValueConversion(typeof(Bitmap), typeof(BitmapImage))]
    public class BitmapToImageSourceConverter : IValueConverter
    {
        static public BitmapToImageSourceConverter Instance = new BitmapToImageSourceConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            Bitmap bitmap = value as Bitmap;
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
