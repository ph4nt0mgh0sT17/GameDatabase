﻿using GameDatabaseResources.Search;
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

        private string searchQuery;
        private ApiEngine apiEngine;
        private GameSearchResult selectedGame;
        private Visibility mGameSearchResultsVisibility;
        private ObservableCollection<GameSearchResult> gameSearchResults = new ObservableCollection<GameSearchResult>();
        private GameInformationPage mGameContent;

        #endregion

        #region Constructor

        /// <summary>
        /// Initiliazing ViewModel
        /// </summary>
        public MainWindowViewModel()
        {
            // Initialize of Api engine
            apiEngine = new ApiEngine();

            // Setting visibility of results as hidden
            GameSearchResultsVisibility = Visibility.Hidden;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets games by parameter query game
        /// </summary>
        /// <param name="queryGame">Text of the game that is searched</param>
        private async void GetGames(string queryGame)
        {
            GameSearchResults.Clear();
            List<GameSearchResult> gameResults = await apiEngine.GetSearchedGames(queryGame);
            gameResults.ToList().ForEach(GameSearchResults.Add);
        }

        /// <summary>
        /// Gets all information about current game.
        /// And sets it to the ScrollViewer -> GameInformation
        /// </summary>
        /// <param name="game">Current game</param>
        private async void GetGameInformation(GameSearchResult game)
        {
            GameInformationModel gameInfo = await apiEngine.GetGame(game);
            GameContent = new GameInformationPage(gameInfo);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Game search results
        /// </summary>
        public ObservableCollection<GameSearchResult> GameSearchResults
        {
            get
            {
                return gameSearchResults;
            }

            set
            {
                gameSearchResults = value;
                RaisePropertyChanged(nameof(GameSearchResults));
            }
        }
        

        

        /// <summary>
        /// Visibility of Game search list results
        /// </summary>
        public Visibility GameSearchResultsVisibility
        {
            get
            {
                return mGameSearchResultsVisibility;
            }

            set
            {
                    mGameSearchResultsVisibility = value;
                    RaisePropertyChanged(nameof(GameSearchResultsVisibility));
            }
        }

        
        /// <summary>
        /// Selected game in SearchResults
        /// </summary>
        public GameSearchResult SelectedGame
        {
            get
            {
                return selectedGame;
            }

            set
            {
                if (value != null)
                {
                    selectedGame = value;
                    GameSearchResults.Clear();
                    GameSearchResultsVisibility = Visibility.Hidden;
                    GetGameInformation(value);
                }
            }
        }

        /// <summary>
        /// Text in textbox -> searching query
        /// </summary>
        public string SearchQuery
        {
            get
            {
                return searchQuery;
            }

            set
            {
                searchQuery = value;

                // If value has something then search results
                if (value != "")
                {
                    GameSearchResultsVisibility = Visibility.Visible;
                    GetGames(value);
                }

                // If value has empty string then set visibility as hidden
                // And clear all results
                else
                {
                    GameSearchResults.Clear();
                    GameSearchResultsVisibility = Visibility.Hidden;
                }
            }
        }

        public GameInformationPage GameContent
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

        private Action EmptyDelegate = delegate () { };

        public RelayCommand ChangeLanguage
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    // Change culture info to english
                    CultureInfo englishCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentCulture = englishCulture;
                    Thread.CurrentThread.CurrentUICulture = englishCulture;

                    // Writes the language into Setting.txt file
                    using (StreamWriter writer = new StreamWriter("Setting.txt"))
                    {
                        writer.WriteLine($"Language=en-US");
                        writer.Flush();
                        writer.Close();
                    }

                    // Restarts the application
                    System.Windows.Forms.Application.Restart();
                    System.Windows.Application.Current.Shutdown();
                }));
            }
        }

        #region Control properties - texts

        public string SearchText
        {
            get
            {
                return Texts.SearchText;
            }
        }

        #endregion

        #endregion

    }
}