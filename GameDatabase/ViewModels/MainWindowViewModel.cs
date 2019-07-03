using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GameDatabase.API;
using GameDatabase.Models.ApiModel;
using GameDatabase.Views;

namespace GameDatabase.ViewModels
{
    public class MainWindowViewModel : DependencyObject
    {
        #region Private variables
        private string searchQuery;
        private ApiEngine apiEngine;
        private GameSearchResult selectedGame;
        private ObservableCollection<GameSearchResult> gameSearchResults = new ObservableCollection<GameSearchResult>();
        private ScrollViewer gameInformation;
        #endregion

        #region Constructor
        /// <summary>
        /// Initiliazing ViewModel
        /// </summary>
        public MainWindowViewModel(ScrollViewer gameInformation)
        {
            // Initialize of Api engine
            apiEngine = new ApiEngine();

            // Setting visibility of results as hidden
            GameSearchResultsVisibility = Visibility.Hidden;

            // Adding ScrollViewer from View into ViewModel so we can handle it
            GameInformation = gameInformation;
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

            GameInfoView view = new GameInfoView(gameInfo);
            GameInformation.Content = new GameInfoView(gameInfo);
        }

        #endregion

        #region Properties
        /// <summary>
        /// Need this scroll viewer to know where to add GameInformationView
        /// </summary>
        public ScrollViewer GameInformation
        {
            get
            {
                return gameInformation;
            }

            set
            {
                gameInformation = value;
            }
        }

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
            }
        }
        
        /// <summary>
        /// Dependency property for visibility of search results so it can be changable during program
        /// </summary>
        public static DependencyProperty SearchResultsVisibility =
            DependencyProperty.Register("GameSearchResultsVisibility", typeof(Visibility), typeof(MainWindowViewModel), new UIPropertyMetadata(Visibility.Hidden));

        /// <summary>
        /// Visibility of Game search results
        /// </summary>
        public Visibility GameSearchResultsVisibility
        {
            get
            {
                return (Visibility)GetValue(SearchResultsVisibility);
            }

            set
            {
                SetValue(SearchResultsVisibility, value);
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

        #endregion


    }
}
