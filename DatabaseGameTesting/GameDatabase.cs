using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameDatabase.API;
using GameDatabase.Models.ApiModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseGameTesting
{
    [TestClass]
    public class GameDatabase
    {
        /// <summary>
        /// Test method for getting game if API_KEY works as it should...
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GettingGame()
        {
            string searchedGame = "The Witcher 3";
            ApiEngine apiEngine = new ApiEngine();

            List<GameSearchResult> game = await apiEngine.GetSearchedGames(searchedGame);

            Assert.IsFalse(game.Count == 0);
        }
    }
}
