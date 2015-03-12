using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace file_renamer
{
    public class Command : ICommand
    {
        private Action<object> m_action;
        private bool m_canExecute;

        public event EventHandler CanExecuteChanged;

        public Command(Action<object> execute)
        {
            m_action = execute;
            m_canExecute = true;
        }

        public void Execute(object param)
        {
            m_action(param);
        }

        public bool CanExecute(object param)
        {
            return m_canExecute;
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
