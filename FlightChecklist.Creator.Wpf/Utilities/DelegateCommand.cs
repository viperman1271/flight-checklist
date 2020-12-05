using System;
using System.Windows.Input;

namespace FlightChecklist.Creator.Wpf
{
    class DelegateCommand : ICommand
    {
        private readonly Action<object> _ExecuteAction;

        public DelegateCommand(Action<object> executeAction)
        {
            _ExecuteAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _ExecuteAction(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
