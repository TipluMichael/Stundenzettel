using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    public class RelayCommand : ICommand
    {
        Action execute;
        Func<bool> canexecute;
        public RelayCommand(Action execute) : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canexecute)
        {
            this.execute = execute;
            this.canexecute = canexecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canexecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            this.execute();
        }
    }

    public class RelayCommand<T> : ICommand
    {
        Action<T> execute;
        Func<T, bool> canexecute;
        public RelayCommand(Action<T> execute) : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canexecute)
        {
            this.execute = execute;
            this.canexecute = canexecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (!(parameter is T || parameter == null))
                return false;
            return canexecute?.Invoke((T)parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            if (!(parameter is T))
                return;
            this.execute((T)parameter);
        }
    }
}
