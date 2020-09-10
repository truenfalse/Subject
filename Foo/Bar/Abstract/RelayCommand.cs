using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bar.Abstract
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        Predicate<object> m_Predicate;
        Action<object> m_Execute;
        public RelayCommand(Action<object> _Execute, Predicate<object> _Predicate = null)
        {
            m_Execute = _Execute;
            m_Predicate = _Predicate;
        }
        public bool CanExecute(object parameter)
        {
            if (m_Predicate == null)
                return true;
            return m_Predicate.Invoke(parameter);
        }
        public void Execute(object parameter)
        {
            m_Execute?.Invoke(parameter);
        }
    }
}
