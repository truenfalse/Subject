using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bar.Abstract
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        #region Fields
        private PropertyChangedEventHandler m_PropertyChanged;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                m_PropertyChanged += value;
            }
            remove
            {
                m_PropertyChanged -= value;
            }
        }
        #endregion

        public void Set<T>(ref T _Field , T _Value, [CallerMemberName]string _PropertyName = null)
        {
            if(_Field != null)
            {
                if (_Field.Equals(_Value))
                    return;
            }
            _Field = _Value;
            OnPropertyChanged(_PropertyName);
        }
        virtual protected void OnPropertyChanged([CallerMemberName]string _PropertyName = null)
        {
            m_PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_PropertyName));
        }
    }
}
