using Bar.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Abstract
{
    public abstract class ParamsBase : ObservableObject, IParams
    {
        /// <summary>
        /// All Property Clone Method
        /// </summary>
        /// <returns> CloneObj </returns>
        virtual public object Clone()
        {
            var PropInfoArray = this.GetType().GetProperties();
            var CloneObj = Activator.CreateInstance(this.GetType());
            foreach (var propinfo in PropInfoArray)
            {
                object val = propinfo.GetValue(this);
                propinfo.SetValue(CloneObj, val);
            }
            return CloneObj;
        }
    }
}
