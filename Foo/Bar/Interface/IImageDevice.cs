using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Interface
{
    public delegate void ImageEventHandler(object sender, IImage args);
    public interface IImageDevice : IDevice
    {
        event ImageEventHandler GrabCompleted;
        bool IsGrabbing { get; }
        /// <summary>
        /// 영상 획득
        /// 파라미터 : GrabbedImage로 영상 출력
        /// GrabbedImage 가 null, Return Value 가 0이 아닌경우 Error
        /// </summary>
        /// <param name="GrabbedImage"></param>
        /// <returns></returns>
        int Grab(out IImage GrabbedImage);
    }
}
