using System;
using System.Windows.Input;

namespace PAC.Windows
{

    public class ActionCommand : ICommand
    {
        private readonly Action<Object> _action;
        private readonly Predicate<Object> _predicate;

        public ActionCommand(Action<Object> action)
            : this(action, null)
        {
        }

        public ActionCommand(Action<Object> action, Predicate<Object> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action", "You must specify an Action<T>.");
            }
            _action = action;
            _predicate = predicate;
        }

        public bool CanExecute(object parameter)
        {
            if (_predicate == null)
            {
                return true;
            }
            return _predicate(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {

            _action(parameter);
        }


        public void Execute()
        {
            Execute(null);
        }
    }
    public class ActionCommand<T> : ICommand
    {
        private readonly Action<T> _action;
        private readonly Predicate<T> _predicate;

        public ActionCommand(Action<T> action)
            : this(action, null)
        {
        }

        public ActionCommand(Action<T> action, Predicate<T> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action", "You must specify an Action<T>.");
            }
            _action = action;
            _predicate = predicate;
        }

        public bool CanExecute(object parameter)
        {
            if (_predicate == null)
            {
                return true;
            }
            return _predicate((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {

            _action((T)parameter);
        }


        public void Execute()
        {
            Execute(null);
        }
    }
}
