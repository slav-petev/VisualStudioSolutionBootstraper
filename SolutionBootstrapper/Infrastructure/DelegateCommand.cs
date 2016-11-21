using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SolutionBootstrapper.Infrastructure
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public DelegateCommand(Action<object> execute) :
            this(execute, null)
        {
            
        }

        public DelegateCommand(Action<object> execute,
            Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        
        public bool CanExecute(object parameter)
        {
            return _canExecute != null
                ? _canExecute(parameter)
                : true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
