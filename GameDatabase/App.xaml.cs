using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GameDatabase
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// This method is executed when the application gets started... 
        /// </summary>
        /// <param name="e">Some event arguements</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            #region Reading Settings file

            string applicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string settingPath = Path.Combine(applicationPath, "Setting.txt");
            // Checking if there is Settings file
            if (File.Exists($"{settingPath}"))
            {
                // Reading from settings file -> This is only testing purpose but there will be more than 1 line in the setting file
                using (StreamReader reader = new StreamReader($"{ applicationPath }\\Setting.txt"))
                {
                    // Reading a line from Setting.txt file
                    string line = reader.ReadLine();

                    // Getting the culture information -> Language, which is I believe cs-cz
                    string cultureInformation = line.Split('=')[1];

                    Setting.Language = cultureInformation;
                }
            }

            // If there is no language set language as default
            else
            {
                Setting.Language = "en-US";
            }

            #endregion
            // Set czech language as default
            CultureInfo currentCulture = new CultureInfo(Setting.Language);
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentCulture;

            SettingsWindowView mainWindow = new SettingsWindowView();
            mainWindow.Show();
        }
    }
}
