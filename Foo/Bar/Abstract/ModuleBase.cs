using Bar.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Abstract
{
    public abstract class ModuleBase : ObservableObject, IModule
    {
        #region Fields
        private string m_Message;
        private int m_ErrorCode;
        private IParams m_InputParams;
        private IParams m_Params;
        private IParams m_OutputParams;
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
        public IParams InputParams 
        {
            get
            {
                return m_InputParams;
            }
            protected set
            {
                Set<IParams>(ref m_InputParams, value);
            }
        }
        public IParams OutputParams 
        {
            get
            {
                return m_OutputParams;
            }
            protected set
            {
                Set<IParams>(ref m_OutputParams, value);
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
                Set<IParams>(ref m_Params, value);
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
        public abstract void Play();
        public abstract void Continuous();
        public abstract void Stop();
        public abstract void Reset();
        #endregion
    }
}
