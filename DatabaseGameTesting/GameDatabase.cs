using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameDatabase;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DatabaseGameTesting
{
    [TestClass]
    public class GameDatabase
    {
        private static List<GameSearchResult> gameResults = new List<GameSearchResult>();
        /// <summary>
        /// Test method for getting game if API_KEY works as it should...
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GettingGame()
        {
            string searchedGame = "The Witcher 3";
            ApiEngine apiEngine = new ApiEngine();

            List<GameSearchResult> games = await apiEngine.GetSearchedGames(searchedGame);

            gameResults.AddRange(games);

            Assert.IsFalse(games.Count == 0);
        }

        [TestMethod]
        public async Task CheckingGames()
        {
            ApiEngine apiEngine = new ApiEngine();

            foreach (GameSearchResult gameSearch in gameResults)
            {
                GameInformationModel game = await apiEngine.GetGame(gameSearch);
                Debug.WriteLine("Name is " + game.Name);
                Assert.IsTrue(game != null);
            }
        }
    }
}
