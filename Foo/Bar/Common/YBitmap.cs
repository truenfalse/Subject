using Bar.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar
{
    public class YBitmap : IImage
    {
        #region Properties
        public int Width 
        {
            get
            {
                return m_Bitmap == null ? 0 : m_Bitmap.Width;
            }
        }
        public int Height
        {
            get
            {
                return m_Bitmap == null ? 0 : m_Bitmap.Height;
            }
        }
        #endregion

        #region Fields
        Bitmap m_Bitmap;
        #endregion
        public YBitmap(Bitmap _Bitmap)
        {
            m_Bitmap = _Bitmap;
        }
        public YBitmap(string ImagePath)
        {
            m_Bitmap = new Bitmap(ImagePath);
        }
        public Bitmap ToBitmap()
        {
            return m_Bitmap;
        }
    }
}
