using Bar.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Devices
{
    public class SimpleImageDeviceParams : ParamsBase
    {
        public List<string> ImagePathCollection 
        {
            get
            {
                return m_ImagePathCollection;
            }
            set
            {
                Set<List<string>>(ref m_ImagePathCollection, value);
            }
        }
        List<string> m_ImagePathCollection;
    }
}
