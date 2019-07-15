using GameDatabaseResources.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GameDatabase
{
    /// <summary>
    /// View model of a MainWindowView
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        #region Private variables

        private Page mGameContent;
        private Window mMainWindow;

        #endregion

        #region Constructors 

        public MainWindowViewModel(Window window)
        {
            mMainWindow = window;
        }

        #endregion

        #region Methods

        private void SetDesignerResources(Window window)
        {
            if (DesignerProperties.GetIsInDesignMode(window))
            {
                
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Current page in frame, these pages will change dynamically
        /// </summary>
        public Page GameContent
        {
            get
            {
                return mGameContent;
            }

            set
            {
                if (value != null)
                {
                    mGameContent = value;
                    RaisePropertyChanged(nameof(GameContent));
                }
            }
        }

        #region Commands

        /// <summary>
        /// Opens settings from menu
        /// </summary>
        public RelayCommand OpenSettings
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    SettingsPage settings = new SettingsPage();
                    GameContent = settings;
                }));
            }
        }

        /// <summary>
        /// Invoked when user click on Search game
        /// </summary>
        public RelayCommand OpenSearchGame
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    SearchGamePage search = new SearchGamePage(this);
                    GameContent = search;
                }));
            }
        }

        #endregion

        #region Control properties - texts

        
        /// <summary>
        /// The application name
        /// </summary>
        public string ApplicationName
        {
            get
            {
                return GameDatabaseResources.Menu.Texts.ApplicationName;
            }
        }

        /// <summary>
        /// Name of the settings menu item
        /// </summary>
        public string SettingsMenu
        {
            get
            {
                return GameDatabaseResources.Menu.Texts.SettingsMenu;
            }
        }

        /// <summary>
        /// Name of a search game menu item
        /// </summary>
        public string SearchGameMenu
        {
            get
            {
                return GameDatabaseResources.Menu.Texts.SearchGameMenu;
            }
        }

        #endregion

        #endregion

    }
}
