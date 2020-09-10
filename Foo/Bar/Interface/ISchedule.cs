using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Interface
{
    public interface ISchedule
    {
        //스케쥴에 할당된 실제 Action
        Action<object> ScheduleAction { get; }
    }
}
