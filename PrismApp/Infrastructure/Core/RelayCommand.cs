using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Infrastructure.Interfaces;

namespace Infrastructure.Core
{
    [Export(typeof(IRelayCommand))]
    public class RelayCommand : IRelayCommand
    {
        private readonly Action _targetExecuteMethod;
        private readonly Func<bool> _targetCanExecuteMethod;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        public RelayCommand(Action executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        /// <param name="canExecuteMethod">The can execute method.</param>
        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }

        /// <summary>Raises the can execute changed.</summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members
        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        bool ICommand.CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                return _targetCanExecuteMethod();
            }
            if (_targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged = delegate { };

        /// <summary>Defines the method to be called when the command is invoked.</summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        void ICommand.Execute(object parameter)
        {
            if (_targetExecuteMethod != null)
            {
                _targetExecuteMethod();
            }
        }
        #endregion
    }

    [Export(typeof(IRelayCommand))]
    public class RelayCommand<T> : IRelayCommand
    {
        readonly Action<T> _targetExecuteMethod;
        readonly Func<T, bool> _targetCanExecuteMethod;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        public RelayCommand(Action<T> executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        /// <param name="canExecuteMethod">The can execute method.</param>
        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }

        /// <summary>Raises the can execute changed.</summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                T tparm = (T)parameter;
                return _targetCanExecuteMethod(tparm);
            }
            if (_targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (_targetExecuteMethod != null)
            {
                _targetExecuteMethod((T)parameter);
            }
        }
        #endregion
    }
}
