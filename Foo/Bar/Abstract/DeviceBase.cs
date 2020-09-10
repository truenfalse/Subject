using Bar.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Abstract
{
    public abstract class DeviceBase : ObservableObject, IDevice
    {
        #region Fields
        private int m_ErrorCode;
        private IParams m_Params;
        private string m_Message;
        #endregion
        #region Properties
        public int ErrorCode 
        {
            get
            {
                return m_ErrorCode;
            }
            protected set
            {
                Set<int>(ref m_ErrorCode, value);
            }
        }
        public IParams Params
        {
            get
            {
                return m_Params;
            }
            protected set
            {
                Set<IParams>(ref m_Params , value);
            }
        }
        public string Message
        {
            get
            {
                return m_Message;
            }
            protected set
            {
                Set<string>(ref m_Message, value);
            }
        }
        #endregion
        #region Public Method
        virtual public void Reset()
        {
            ErrorCode = 0;
            Message = string.Empty;
        }
        #endregion
    }
}
