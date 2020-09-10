using Bar.Abstract;
using Bar.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bar.Modules
{
    /// <summary>
    /// 모션 이동후 이미지 촬상
    /// </summary>
    // Input : 도착위치
    // Output : 이미지
    public class MotionGrabModule : ModuleBase
    {
        #region Fields
        bool m_IsRunContinuous;
        Task m_ContiTask;
        #endregion
        #region Properties
        public IMotionDevice Motion { get; set; } // 사용될 모션
        public IImageDevice Camera { get; set; } // 사용될 이미지 획득 디바이스
        #endregion
        #region Constructor
        public MotionGrabModule()
        {
            InputParams = new MotionGrabModuleInputParams();
            Params = new MotionGrabModuleParams();
            OutputParams = new MotionGrabModuleOutputParams();
        }
        #endregion
        #region Public Method
        public override void Play()
        {

            if (Motion == null)
            {
                ErrorCode = -1;
                Message = "Motion Is Null";
                return;
            }
            if(Camera == null)
            {
                ErrorCode = -2;
                Message = "Camera is Null";
                return;
            }

            MotionGrabModuleInputParams motionGrabInputParams = (InputParams as MotionGrabModuleInputParams);
            double TargetPosition = motionGrabInputParams.TargetPosition;

            int iResult = Motion.Move(TargetPosition);
            if(iResult != 0)
            {
                Message = "Motion Move Error";
                ErrorCode = -3;
            }    

            while(Motion.IsMoving == true)
            {
                Thread.Sleep(1);
                // Wait Moving Position
            }

            IImage GrabbedImage;
            iResult = Camera.Grab(out GrabbedImage);
            if(iResult != 0)
            {
                Message = "Image Grab Error";
                ErrorCode = -4;
            }
            (OutputParams as MotionGrabModuleOutputParams).OutputImage = GrabbedImage;
        }
        public override void Continuous()
        {
            if (m_ContiTask != null)
                return;
            if (m_IsRunContinuous == true)
                return;
            m_IsRunContinuous = true;
            m_ContiTask = Task.Run(() =>
            {
                while (m_IsRunContinuous)
                {
                    Thread.Sleep(15);
                    if (Motion.Position != 0)
                    {
                        Reset();
                    }
                    Play();
                }
            });
        }
        public override void Stop()
        {
            if (m_IsRunContinuous == false)
                return;
            if(m_ContiTask == null)
                return;
            m_IsRunContinuous = false;
            m_ContiTask.Wait();
            m_ContiTask.Dispose();
            m_ContiTask = null;
        }
        public override void Reset()
        {
            if(Motion.Position != 0)
            {
                Motion.Move(0);
            }
            Camera.Reset();
            while(Motion.IsMoving == true)
            {
                Thread.Sleep(1);
            }
            return;
        }
        #endregion
    }
}
