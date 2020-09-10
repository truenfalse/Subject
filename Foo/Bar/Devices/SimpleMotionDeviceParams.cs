using Bar.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Bar.Abstract;

namespace Bar.Devices
{
    public class SimpleMotionDeviceParams : ParamsBase
    {
        #region Fields
        private double m_MotionSpeed;
        private List<double> m_TriggerPosCollection;
        #endregion
        #region Properties
        /// <summary>
        /// Simple이라 간단하게 1mm가는데 걸린 시간으로 측정
        /// Motion Speed 1mm가는데 걸린 시간 입력 
        /// 시간단위는 ms
        /// </summary>
        public double MotionSpeed 
        {
            get
            {
                return m_MotionSpeed;
            }
            set
            {
                Set<double>(ref m_MotionSpeed, value);
            }
        }
        /// <summary>
        /// Trigger가 발생하는 Position 등록
        /// double Value로 Sorting 되있어야 합니다.
        /// </summary>
        public List<double> TriggerPosCollection 
        {
            get
            {
                return m_TriggerPosCollection;
            }
            set
            {
                Set<List<double>>(ref m_TriggerPosCollection, value);
            }
        }
        #endregion
        public SimpleMotionDeviceParams()
        {

        }
    }
}
