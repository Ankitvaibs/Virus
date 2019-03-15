using System;
using System.Windows.Input;

namespace StressTestSimulator.ViewModels
{
    public class DelegatedParameterlessCommand : ICommand
    {
        private readonly Func<bool> _canExecuteAction;
        private readonly Action _action;

        public DelegatedParameterlessCommand(Action action, Func<bool> canExecuteAction = null)
        {
            _canExecuteAction = canExecuteAction;
            _action = action;
        }

        public virtual bool CanExecute(object parameter)
        {
            return _canExecuteAction?.Invoke() ?? true;
        }

        public virtual void Execute(object parameter)
        {
            _action?.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}