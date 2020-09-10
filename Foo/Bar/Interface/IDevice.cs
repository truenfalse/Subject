using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Interface
{
    /// <summary>
    /// Device
    /// 장치 관련 오브젝트
    /// 각 장치의 Library에 따라 구현
    /// </summary>
    public interface IDevice
    {
        string Message { get; }
        IParams Params { get; }
        void Reset();
    }
}
