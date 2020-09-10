using Bar.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Modules
{
    public class MotionGrabModuleInputParams : ParamsBase
    {
        private double m_TargetPosition;
        #region Properties
        public double TargetPosition
        {
            get
            {
                return m_TargetPosition;
            }
            set
            {
                Set<double>(ref m_TargetPosition, value);
            }
        }
        #endregion
    }
}
