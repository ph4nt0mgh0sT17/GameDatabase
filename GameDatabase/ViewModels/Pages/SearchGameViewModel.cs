using GameDatabaseResources.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace GameDatabase
{
    /// <summary>
    /// A View model for <see cref="SearchGamePage"/>
    /// </summary>
    public class SearchGameViewModel : BaseViewModel
    {
        #region Private variables

        private string searchQuery;
        private ApiEngine apiEngine;
        private GameSearchResult selectedGame;
        private Visibility mGameSearchResultsVisibility;
        private ObservableCollection<GameSearchResult> gameSearchResults = new ObservableCollection<GameSearchResult>();

        #endregion

        #region Constructor

        /// <summary>
        /// Initiliazing ViewModel
        /// </summary>
        public SearchGameViewModel()
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

        #region User control text - Constant

        /// <summary>
        /// The name of search textblock
        /// </summary>
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
