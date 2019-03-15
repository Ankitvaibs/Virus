using System;
using System.Windows.Input;

namespace StressTestSimulator.ViewModels
{
    public class DelegatedCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecuteAction;
        private readonly Action<T> _action;

        public DelegatedCommand(Action<T> action, Func<T, bool> canExecuteAction = null)
        {
            _canExecuteAction = canExecuteAction;
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteAction?.Invoke((T)(parameter is T ? parameter : null)) ?? true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke((T)(parameter is T ? parameter : null));
        }

        public event EventHandler CanExecuteChanged;
    }
}