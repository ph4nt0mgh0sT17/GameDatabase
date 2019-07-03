using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GameDatabase.API;
using GameDatabase.Models.ApiModel;


namespace GameDatabase.ViewModels
{
    public class MainWindowViewModel : DependencyObject
    {
        private string searchQuery;
        private ApiEngine apiEngine;
        private GameSearchResult selectedGame;
        private ObservableCollection<GameSearchResult> gameSearchResults = new ObservableCollection<GameSearchResult>();

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
                selectedGame = value;
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


    }
}
