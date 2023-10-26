#nullable disable
using System;
using System.Windows.Input;

namespace FinancialApp.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;

        private readonly Func<object, bool> _canExecute;

        public RelayCommand() { }

        public RelayCommand(Action<object> _execute)
        {
            this._execute = _execute;
            _canExecute = null;
        }

        public RelayCommand(Action<object> _execute, Func<object, bool> _canExecute)
        {
            this._execute = _execute;
            this._canExecute = _canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
