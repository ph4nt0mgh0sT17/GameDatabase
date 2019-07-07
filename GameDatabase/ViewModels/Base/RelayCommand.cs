using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameDatabase
{

    public class RelayCommand : ICommand
    {
        #region Private members

        Action methodToBeExecuted;
        Func<bool> canBeMethodToBeExecuted;

        #endregion

        #region Constructors

        /// <summary>
        /// This constructor creates command that will be surely executed 
        /// </summary>
        /// <param name="methodToBeExecuted">Method that will be executed</param>
        public RelayCommand(Action methodToBeExecuted)
        {
            this.methodToBeExecuted = methodToBeExecuted;
        }

        
        /// <summary>
        /// Creates command with <see cref="methodToBeExecuted" /> that will be executed if <see cref="canBeMethodToBeExecuted"/> will be true/>
        /// </summary>
        /// <param name="methodToBeExecuted">Method that will be executed</param>
        /// <param name="canBeMethodToBeExecuted">Boolean parameter that determines whether the method will be executed or not</param>
        public RelayCommand(Action methodToBeExecuted, Func<bool> canBeMethodToBeExecuted)
        {
            this.methodToBeExecuted = methodToBeExecuted;
            this.canBeMethodToBeExecuted = canBeMethodToBeExecuted;
        }

        #endregion

        #region Public events

        public event EventHandler CanExecuteChanged = delegate { };

        #endregion

        #region Command methods

        /// <summary>
        /// Fires everytime that '<see cref="canBeMethodToBeExecuted"/>' changes...
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Determines if command can be executed
        /// </summary>
        bool ICommand.CanExecute(object parameter)
        {
            if (canBeMethodToBeExecuted != null)
            {
                return canBeMethodToBeExecuted();
            }

            if (methodToBeExecuted != null)
            {
                return true;
            }

            return false;
        }

        
        /// <summary>
        /// Executes the command if command is not null
        /// </summary>
        void ICommand.Execute(object parameter)
        {
            methodToBeExecuted?.Invoke();
        }

        #endregion
    }
}
