using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDatabase.API;
using GameDatabase.Models.ApiModel;

namespace GameDatabase.ViewModels
{
    public class MainWindowViewModel
    {
        private string query;
        private ApiEngine apiEngine;

        private ObservableCollection<GameSearchResult> results = new ObservableCollection<GameSearchResult>();
        public MainWindowViewModel()
        {
            apiEngine = new ApiEngine();
        }

        private async void GetGames(string queryGame)
        {
            Results.Clear();
            List<GameSearchResult> gameResults = await apiEngine.GetSearchedGames(queryGame);
            gameResults.ToList().ForEach(Results.Add);
        }

        public ObservableCollection<GameSearchResult> Results
        {
            get
            {
                return results;
            }

            set
            {
                results = value;
            }
        }

        public string Query
        {
            get
            {
                return query;
            }

            set
            {
                query = value;
                GetGames(value);
            }
        }
    }
}
