using Bar.Abstract;
using Bar.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Modules
{
    public class MotionGrabModuleOutputParams : ParamsBase
    {
        #region Fields
        IImage m_OutputImage;
        #endregion
        #region Properties
        public IImage OutputImage
        {
            get
            {
                return m_OutputImage;
            }
            set
            {
                Set<IImage>(ref m_OutputImage, value);
            }
        }
        #endregion
        public MotionGrabModuleOutputParams()
        {
            
        }
    }
}
