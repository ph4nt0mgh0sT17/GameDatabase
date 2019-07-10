using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
            MainWindowView mainWindow = new MainWindowView();
            mainWindow.Show();
        }
    }
}
