using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Interface
{
    /// <summary>
    /// sender is MotionDevice
    /// args is MotionDevice CurrentPosition
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void MotionEventHandler(object sender, double args);

    public interface IMotionDevice : IDevice
    {
        double Position { get; }
        /// <summary>
        /// 현재 움직이고 있는지 알려주는 Flag
        /// </summary>
        bool IsMoving { get; }

        /// <summary>
        /// Move시 등록된 위치마다 Event 발생
        /// </summary>
        event MotionEventHandler MoveTriggerOccured;

        /// <summary>
        /// Move완료시 Event 발생
        /// </summary>
        event MotionEventHandler MoveCompleted;

        /// <summary>
        /// 포지션으로 이동하는 명령어 Position은 절대값
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        int Move(double Position);
    }
}
