using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Bar.Interface
{
    public interface IImage
    {
        Bitmap ToBitmap();
    }
}
