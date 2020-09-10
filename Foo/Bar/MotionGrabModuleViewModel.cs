using Bar.Abstract;
using Bar.Interface;
using Bar.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bar
{
    public class MotionGrabModuleViewModel : ViewModelBase
    {
        #region Fields
        private MotionGrabModule m_Module;
        private ObservableCollection<string> m_ModuleMessages;
        #endregion
        #region Properties
        public MotionGrabModule Module 
        {
            get
            {
                return m_Module;
            }
            set
            {
                if (m_Module != null)
                    m_Module.PropertyChanged -= MessagePropertyChanged;
                if (value != null)
                    value.PropertyChanged += MessagePropertyChanged;
                Set<MotionGrabModule>(ref m_Module, value);
            }
        }
        public ObservableCollection<string> ModuleMessages
        {
            get
            {
                return m_ModuleMessages;
            }
            set
            {
                Set<ObservableCollection<string>>(ref m_ModuleMessages, value);
            }
        }
        private void MessagePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Message")
            {
                ModuleMessages.Add((sender as IModule).Message);
            }
        }
        #endregion
        #region Commands
        public ICommand PlayCommand { get; set; }
        public ICommand ContinuousCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        #endregion
        #region Constructor
        public MotionGrabModuleViewModel()
        {
            m_ModuleMessages = new ObservableCollection<string>();
            PlayCommand = new RelayCommand(PlayAction, ModuleCommandPredicate);
            ContinuousCommand = new RelayCommand(ContinuousAction, ModuleCommandPredicate);
            StopCommand = new RelayCommand(StopAction, ModuleCommandPredicate);
            ResetCommand = new RelayCommand(ResetAction, ModuleCommandPredicate);
        }
        #endregion
        private bool ModuleCommandPredicate(object obj)
        {
            if (Module == null)
                return false;
            return true;
        }

        private void PlayAction(object obj)
        {
            Task.Run(() =>
            {
                Module.Play();
            });
        }

        private void ContinuousAction(object obj)
        {
            Module.Continuous();
        }

        private void StopAction(object obj)
        {
            Module.Stop();
        }
        private void ResetAction(object obj)
        {
            Task.Run(() =>
            {
                Module.Reset();
            });
        }
    }
}
