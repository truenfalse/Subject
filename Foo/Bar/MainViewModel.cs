using Bar.Abstract;
using Bar.Devices;
using Bar.Interface;
using Bar.Modules;
using System.Collections.ObjectModel;

namespace Bar
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private ObservableCollection<ViewModelBase> m_DeviceViewModels;
        private ObservableCollection<ViewModelBase> m_ModuleViewModels;
        #endregion

        #region Properties
        public ObservableCollection<ViewModelBase> Devices 
        {
            get
            {
                return m_DeviceViewModels;
            }
            set
            {
                Set<ObservableCollection<ViewModelBase>>(ref m_DeviceViewModels, value);
            }
        }
        public ObservableCollection<ViewModelBase> Modules 
        {
            get
            {
                return m_ModuleViewModels;
            }
            set
            {
                Set<ObservableCollection<ViewModelBase>>(ref m_ModuleViewModels, value);
            }
        }
        #endregion
        public MainViewModel()
        {
            Devices = new ObservableCollection<ViewModelBase>();
            Modules = new ObservableCollection<ViewModelBase>();

            SimpleMotionDevice Motion = new SimpleMotionDevice();
            SimpleImageDevice Camera = new SimpleImageDevice();
            MotionGrabModule Module = new MotionGrabModule() { Motion = Motion, Camera = Camera };

            Devices.Add(new SimpleMotionDeviceViewModel() { Device = Motion});
            Devices.Add(new SimpleImageDeviceViewModel() { Device = Camera});

            Modules.Add(new MotionGrabModuleViewModel() { Module = Module});
        }
    }
}