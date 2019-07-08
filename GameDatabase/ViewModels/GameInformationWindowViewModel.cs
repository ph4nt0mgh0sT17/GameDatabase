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

        private string mVersion;
        private string mVersion2;

        #endregion

        private int counter;

        /// <summary>
        /// Default constructor
        /// </summary>
        public GameInformationWindowViewModel()
        {
            Version = "Game Database 1.00";
            VersionV2 = "Game Database v1.00";
            GenerateVersionCommand = new AsyncRelayCommand(GenerateVersion);
            counter = 0;
        }
        
        /// <summary>
        /// Automatically generates asynchronous method which generates version of the application for test purposes
        /// </summary>
        /// <returns></returns>
        private async Task GenerateVersion()
        {
            // Clear version
            Version = "Game Database v1.";
            VersionV2 = "Game Database v1.";

            // Instantiate generator of automatic generation...
            Random generator = new Random();

            // Loop for generating some chars from ASCII table for test if binding works
            for (int i = 0; i < 4; i++)
            {
                int generatedNumber = generator.Next(0, 10);
                Version += generatedNumber.ToString();
                await Task.Delay(100);
            }

            // Loop for generating some chars from ASCII table for test if binding works
            for (int i = 0; i < 4; i++)
            {
                int generatedNumber = generator.Next(0, 10);
                VersionV2 += generatedNumber.ToString();
                await Task.Delay(100);
            }
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

        /// <summary>
        /// Another version of the application
        /// </summary>
        public string VersionV2
        {
            get
            {
                return mVersion2;
            }

            set
            {
                if (value != null)
                {
                    mVersion2 = value;
                    RaisePropertyChanged(nameof(VersionV2));
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
