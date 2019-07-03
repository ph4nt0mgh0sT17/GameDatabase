using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameDatabase.ViewModels
{
    public class Command : ICommand
    {
        Action methodToBeExecuted;
        Func<bool> canBeMethodToBeExecuted;

        public Command(Action methodToBeExecuted)
        {
            this.methodToBeExecuted = methodToBeExecuted;
        }

        

        public Command(Action methodToBeExecuted, Func<bool> canBeMethodToBeExecuted)
        {
            this.methodToBeExecuted = methodToBeExecuted;
            this.canBeMethodToBeExecuted = canBeMethodToBeExecuted;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

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

        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (methodToBeExecuted != null)
            {
                methodToBeExecuted();
            }
        }
    }
}
