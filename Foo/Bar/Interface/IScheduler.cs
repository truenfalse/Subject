using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Interface
{
    /// <summary>
    /// 할당된 스케쥴 관리
    /// </summary>
    public interface IScheduler
    {
        /// <summary>
        /// 관리중인 스케쥴
        /// </summary>
        List<ISchedule> Schedules { get; }
    }
}
