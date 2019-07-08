using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;

namespace GameDatabase
{
    public class AsyncRelayCommand : ICommand
    {
        #region Private members

        private bool mIsExecuting;
        private readonly Func<Task> mExecute;
        private readonly Func<bool> mCanExecute;
        private readonly IErrorHandler mErrorHandler;

        #endregion

        #region Public events

        public event EventHandler CanExecuteChanged = delegate { };

        #endregion

        #region Constructors

        /// <summary>
        /// This constructor creates command that will be surely executed 
        /// </summary>
        /// <param name="methodToBeExecuted">Method that will be executed</param>
        public AsyncRelayCommand(Func<Task> methodToBeExecuted)
        {
            if (methodToBeExecuted == null)
            {
                throw new NullReferenceException("Async relay command has to have defined method.");
            }

            else
            {
                this.mExecute = methodToBeExecuted;
                mCanExecute = null;
                mErrorHandler = null;
            }
        }


        /// <summary>
        /// Creates command with <see cref="mExecute" /> that will be executed if <see cref="mCanExecute"/> will be true/>
        /// </summary>
        /// <param name="methodToBeExecuted">Method that will be executed</param>
        /// <param name="canBeMethodToBeExecuted">Boolean parameter that determines whether the method will be executed or not</param>
        public AsyncRelayCommand(Func<Task> methodToBeExecuted, Func<bool> canBeMethodToBeExecuted)
        {
            this.mExecute = methodToBeExecuted;
            this.mCanExecute = canBeMethodToBeExecuted;
            mErrorHandler = null;
        }

        #endregion



        #region Command methods

        public bool CanExecute()
        {
            return !mIsExecuting && (mCanExecute?.Invoke() ?? true);
        }

        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    mIsExecuting = true;
                    RaiseCanExecuteChanged();
                    await mExecute();
                }

                finally
                {
                    mIsExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Fires everytime that '<see cref="mCanExecute"/>' changes...
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Determines if command can be executed
        /// </summary>
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }


        /// <summary>
        /// Executes the command if command is not null
        /// </summary>
        void ICommand.Execute(object parameter)
        {
            ExecuteAsync();
        }

        #endregion
    }
}
