using Bar.Abstract;
using Bar.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bar.Devices
{
    public class SimpleMotionDevice : DeviceBase, IMotionDevice
    {
        #region Fields
        private bool m_IsMoving;
        private Task<int> m_MotionTask;
        private bool m_EmergencyStop;
        private double m_Position;
        private MotionEventHandler m_MoveCompleted;
        private MotionEventHandler m_MoveTriggerOccured;
        #endregion

        #region Properties
        public bool IsMoving
        {
            get
            {
                return m_IsMoving;
            }
            private set
            {
                Set<bool>(ref m_IsMoving, value);
            }
        }
        public bool EmergencyStop
        {
            get
            {
                return m_EmergencyStop;
            }
            set
            {
                m_EmergencyStop = value;
            }
        }
        public double Position
        {
            get
            {
                return m_Position;
            }
            set
            {
                Set<double>(ref m_Position, value);
            }
        }
        #endregion

        #region Events
        public event MotionEventHandler MoveTriggerOccured
        {
            add
            {
                m_MoveTriggerOccured += value;
            }
            remove
            {
                m_MoveTriggerOccured -= value;
            }
        }
        public event MotionEventHandler MoveCompleted
        {
            add
            {
                m_MoveCompleted += value;
            }
            remove
            {
                m_MoveCompleted -= value;
            }
        }
        #endregion

        #region Constructor
        public SimpleMotionDevice()
        {
            Params = new SimpleMotionDeviceParams();
        }
        #endregion

        #region Public Methods
        public int Move(double TargetPosition)
        {
            // Emergency Stop 체크
            if (EmergencyStop == true)
            {
                Message = "Check EmergencyStop";
                ErrorCode = -1;
                return -1;
            }

            // 이미 움직이는 중이라면 Error 발생
            if (IsMoving == true)
            {
                Message = "Check Current MotionDevice(Move Already)";
                ErrorCode = -2;
                return -2;
            }

            // Device 초기화
            ErrorCode = 0;
            Message = string.Empty;


            // 먼저 시작을 알림
            IsMoving = true;
            m_MotionTask = Task.Run(() =>
            {
                return InternalMove(TargetPosition);
            });
            return 0; // 무빙 신호 보내기 완료;
        }
        #endregion

        #region Private Methods
        private int InternalMove(double TargetPosition)
        {
            SimpleMotionDeviceParams SimpleMotionDeviceParams = (Params as SimpleMotionDeviceParams);

            //파라미터 복사 무빙중 변경 방지
            double MotionSpeed = SimpleMotionDeviceParams.MotionSpeed;
            List<double> TriggerPosCollection = new List<double>();
            int MotionDirection = m_Position > TargetPosition ? -1 : 1; // 현재위치와 대상위치 비교후 방향설정
            bool MotionTriggerOnOff = SimpleMotionDeviceParams.TriggerPosCollection == null ? false : true;
            int CheckMotionTriggerIndex = 0;

            if (MotionTriggerOnOff == true)
            {
                CheckMotionTriggerIndex = MotionDirection > 0 ? 0 : SimpleMotionDeviceParams.TriggerPosCollection.Count - 1; // 몇번째 인덱스를 체크해야하는지 알려주는 인덱스
                foreach (double TriggerPos in SimpleMotionDeviceParams.TriggerPosCollection)
                {
                    TriggerPosCollection.Add(TriggerPos);
                }
            }
            bool Moving = true;
            while (Moving) //현재 위치가 타겟 위치에 도달할때까지 계속
            {
                if (m_EmergencyStop == true)
                {
                    Message = "Emergency Stop Button Pressed In Moving";
                    return -3;
                }
                Thread.Sleep(TimeSpan.FromMilliseconds(MotionSpeed));
                if (MotionTriggerOnOff == true )
                {
                    if (m_Position == TriggerPosCollection[CheckMotionTriggerIndex])
                    {
                        OnMoveTriggerOccured();
                        Message = string.Format("Trigger Occured : {0}", CheckMotionTriggerIndex);
                        CheckMotionTriggerIndex += 1 * MotionDirection; // Trigger Position으로 Sort 되어있어 방향이 역방향일 경우 인덱스를 거꾸로 내립니다.
                    }
                    if (MotionDirection > 0 && CheckMotionTriggerIndex == TriggerPosCollection.Count)
                        MotionTriggerOnOff = false;
                    else if (MotionDirection < 0 && CheckMotionTriggerIndex < 0)
                        MotionTriggerOnOff = false;
                }
                if (Position == TargetPosition)
                    Moving = false;
                else
                    Position = m_Position + MotionDirection;
            }
            OnMoveCompleted();
            IsMoving = false;
            return 0; // 정상종료
        }
        #endregion

        #region OnEvents
        private void OnMoveCompleted()
        {
            m_MoveCompleted?.Invoke(this, m_Position);
        }
        private void OnMoveTriggerOccured()
        {
            m_MoveTriggerOccured?.Invoke(this, m_Position);
        }

        public override void Reset()
        {
            
        }
        #endregion
    }
}
