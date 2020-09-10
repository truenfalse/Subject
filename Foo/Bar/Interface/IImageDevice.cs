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
        int Grab(out IImage GrabbedImage);
    }
}
