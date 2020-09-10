using Bar.Abstract;
using Bar.Devices;
using Bar.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Bar
{
    public class SimpleMotionDeviceViewModel : ViewModelBase
    {
        private ObservableCollection<IndexValue> m_TriggerPosition;
        private ObservableCollection<string> m_DeviceMessages;
        private SimpleMotionDevice m_Device;

        public ObservableCollection<string> DeviceMessages 
        {
            get
            {
                return m_DeviceMessages;
            }
            set
            {
                Set<ObservableCollection<string>>(ref m_DeviceMessages, value);
            }
        }
        public SimpleMotionDevice Device 
        {
            get
            {
                return m_Device;
            }
            set
            {
                if(m_Device != null)
                    m_Device.PropertyChanged -= MessagePropertyChanged;
                if (value != null)
                    value.PropertyChanged += MessagePropertyChanged;
                Set<SimpleMotionDevice>(ref m_Device, value);
            }
        }

        private void MessagePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Message")
                App.Current.Dispatcher.Invoke(() =>
                {
                    m_DeviceMessages.Insert(0,(sender as IDevice).Message);
                });
        }

        public ObservableCollection<IndexValue> TriggerPosition
        {
            get
            {
                return m_TriggerPosition;
            }
            set
            {
                Set<ObservableCollection<IndexValue>>(ref m_TriggerPosition, value);
            }
        }
        public ICommand MoveCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand TriggerPositionAddCommand { get; set; }
        public ICommand TriggerPositionSetCommand { get; set; }
        public SimpleMotionDeviceViewModel()
        {
            m_DeviceMessages = new ObservableCollection<string>();
            m_TriggerPosition = new ObservableCollection<IndexValue>();
            MoveCommand = new RelayCommand(MoveAction);
            ResetCommand = new RelayCommand(ResetAction);
            TriggerPositionAddCommand = new RelayCommand(TriggerPositionAddAction);
            TriggerPositionSetCommand = new RelayCommand(TriggerPositionSetAction);
        }

        private void ResetAction(object obj)
        {
            Device.Reset();
        }

        private void MoveAction(object obj)
        {
            if (obj == null)
            {
                MessageBox.Show("TargetPosition is Null");
                return;
            }
            Device.Move((double)obj);
        }

        private void TriggerPositionSetAction(object obj)
        {
            (Device.Params as SimpleMotionDeviceParams).TriggerPosCollection = (from indexVal in TriggerPosition
                                                                               select indexVal.Value).ToList();
            MessageBox.Show("Set Completed");
        }

        private void TriggerPositionAddAction(object obj)
        {
            TriggerPosition.Add(new IndexValue(TriggerPosition.Count));
            MessageBox.Show("Add Completed");
        }
    }
    public class IndexValue : ObservableObject
    {
        #region Fields
        private double m_index;
        private double m_Value;
        #endregion
        public double Index 
        {
            get
            {
                return m_index;
            }
        }
        public double Value 
        {
            get
            {
                return m_Value;
            }
            set
            {
                Set<double>(ref m_Value,value);
            }
        }
        public IndexValue(int Index)
        {
            m_index = Index;
        }
    }
}
