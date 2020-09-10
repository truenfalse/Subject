using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Interface
{
    public interface IModule
    {
        /// <summary>
        /// 모듈 플레이시 필요한 데이터 자주 변경되는 데이터들이 들어감
        /// </summary>
        IParams InputParams { get; } 
        /// <summary>
        /// 모듈 플레이 후 결과
        /// </summary>
        IParams OutputParams { get; }
        /// <summary>
        /// 모듈의 주요 구성 데이터
        /// </summary>
        IParams Params { get; }
        string Message { get; }
        void Play();
        void Continuous();
        void Stop();
    }
}
