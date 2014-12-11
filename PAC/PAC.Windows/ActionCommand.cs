// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionCommand.cs" company="J.N Systems">
//   .
// </copyright>
// <summary>
//   Defines the ActionCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PAC.Windows
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// The class with implementation of the ICommand interface
    /// </summary>
    public class ActionCommand : ICommand
    {
        /// <summary>
        /// The action.
        /// </summary>
        private readonly Action<object> action;

        /// <summary>
        /// The predicate.
        /// </summary>
        private readonly Predicate<object> predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        public ActionCommand(Action<object> action)
            : this(action, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Argument is null
        /// </exception>
        public ActionCommand(Action<object> action, Predicate<object> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action", "You must specify an Action<T>.");
            }

            this.action = action;
            this.predicate = predicate;
        }

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// The can execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (this.predicate == null)
            {
                return true;
            }

            return this.predicate(parameter);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Execute(object parameter)
        {
            this.action(parameter);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        public void Execute()
        {
            this.Execute(null);
        }
    }

    /// <summary>
    /// The action command.
    /// </summary>
    /// <typeparam name="T">
    /// Can be used with any Type of object
    /// </typeparam>
    public class ActionCommand<T> : ICommand
    {
        /// <summary>
        /// The action.
        /// </summary>
        private readonly Action<T> action;

        /// <summary>
        /// The predicate.
        /// </summary>
        private readonly Predicate<T> predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand{T}"/> class.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        public ActionCommand(Action<T> action)
            : this(action, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand{T}"/> class.
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If action is null
        /// </exception>
        public ActionCommand(Action<T> action, Predicate<T> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action", "You must specify an Action<T>.");
            }

            this.action = action;
            this.predicate = predicate;
        }

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// The can execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (this.predicate == null)
            {
                return true;
            }

            return this.predicate((T)parameter);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Execute(object parameter)
        {
            this.action((T)parameter);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        public void Execute()
        {
            this.Execute(null);
        }
    }
}
