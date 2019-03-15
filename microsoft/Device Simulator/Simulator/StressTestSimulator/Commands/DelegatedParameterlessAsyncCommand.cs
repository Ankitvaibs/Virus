using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StressTestSimulator.ViewModels
{
    public class DelegatedParameterlessAsyncCommand : ICommand, IAsyncCommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Func<Task> _action;
        private readonly Func<bool> _canExecute;

        public DelegatedParameterlessAsyncCommand(Func<Task> action, Func<bool> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync();
        }


        public async Task ExecuteAsync()
        {
            await _action();
        }
    }
}