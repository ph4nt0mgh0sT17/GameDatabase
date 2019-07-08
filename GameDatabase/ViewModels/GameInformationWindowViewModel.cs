using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase
{
    public class GameInformationWindowViewModel : BaseViewModel
    {
        #region Private members

        string mVersion;

        #endregion

        private int counter;

        /// <summary>
        /// Default constructor
        /// </summary>
        public GameInformationWindowViewModel()
        {
            Version = "Game Database 1.00";
            GenerateVersionCommand = new AsyncRelayCommand(GenerateVersion);
            counter = 0;
        }
        
        /// <summary>
        /// Automatically generates asynchronous method which generates version of the application for test purposes
        /// </summary>
        /// <returns></returns>
        private async Task GenerateVersion()
        {
            counter = 1;
            // Clear version
            Version = "Game Database v1.";

            // Instantiate generator of automatic generation...
            Random generator = new Random();

            // Loop for generating some chars from ASCII table for test if binding works
            for (int i = 0; i < 4; i++)
            {
                int generatedNumber = generator.Next(0, 10);
                Version += generatedNumber.ToString();
                await Task.Delay(100);
            }
            counter = 0;
        }

        private bool CanExecute()
        {
            return counter == 0;
        }

        #region Properties

        /// <summary>
        /// Version of the application
        /// </summary>
        public string Version
        {
            get
            {
                return mVersion;
            }

            set
            {
                if (value != null)
                {
                    mVersion = value;
                    RaisePropertyChanged(nameof(Version));
                }
            }
        }

        public AsyncRelayCommand GenerateVersionCommand
        {
            get; set;
        }

        #endregion
    }
}
