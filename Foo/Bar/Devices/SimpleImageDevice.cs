using Bar.Abstract;
using Bar.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Devices
{
    /// <summary>
    /// 이미지 로드후 
    /// </summary>
    public class SimpleImageDevice : DeviceBase, IImageDevice
    {
        #region Properties
        public bool IsGrabbing 
        {
            get
            {
                return m_IsGrabbing;
            }
            private set
            {
                Set<bool>(ref m_IsGrabbing, value);
            }
        }
        public int ImageIndex
        {
            get
            {
                return m_ImageIndex;
            }
            private set
            {
                Set<int>(ref m_ImageIndex, value);
            }
        }
        #endregion

        #region Fields
        private ImageEventHandler m_GrabCompleted;
        private bool m_IsGrabbing;
        private int m_ImageIndex;
        #endregion

        #region Events
        public event ImageEventHandler GrabCompleted
        {
            add
            {
                m_GrabCompleted += value;
            }
            remove
            {
                m_GrabCompleted -= value;
            }
        }
        #endregion

        #region Constructor
        public SimpleImageDevice()
        {
            Params = new SimpleImageDeviceParams();
        }
        #endregion

        #region Public Methods
        public int Grab(out IImage GrabbedImage)
        {
            if(IsGrabbing == true)
            {
                ErrorCode = -1;
                Message = "Device does already grabbing";
                GrabbedImage = null;
                return -1;
            }

            // Device ErrorCode or Message Initialize
            IsGrabbing = true;
            ErrorCode = 0;
            Message = "";

            // Device Action
            GrabbedImage = InternalGrab();
            if (GrabbedImage == null)
                OnGrabCompleted(GrabbedImage);
            Message = "Grab Completed";
            IsGrabbing = false;
            return ErrorCode;
        }
        override public void Reset()
        {
            base.Reset();
        }
        #endregion
        #region Private Methods
        private IImage InternalGrab()
        {
            SimpleImageDeviceParams simpleImageDeviceParams = (Params as SimpleImageDeviceParams);

            //Check ImagePath Collection
            if (simpleImageDeviceParams.ImagePathCollection == null || !(simpleImageDeviceParams.ImagePathCollection.Count > 0))
            {
                Message = "ImagePathCollection is null or Empty";
                ErrorCode = -2;
                return null;
            }

            int Count = simpleImageDeviceParams.ImagePathCollection.Count;
            if (ImageIndex >= Count)
                ImageIndex %= Count;

            try
            {
                YBitmap Image = new YBitmap(simpleImageDeviceParams.ImagePathCollection[ImageIndex++]);
                return Image;
            }
            catch
            {
                ErrorCode = -3;
                Message = "File is not Image";
                return null;
            }
        }
        #endregion
        #region OnEvents
        private void OnGrabCompleted(IImage args)
        {
            m_GrabCompleted?.Invoke(this, args);
        }
        #endregion
    }
}
