﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GameDatabase
{
    public class ApiEngine
    {
        /// <summary>
        /// Api key which is mandatory in queries we will be using
        /// </summary>
        private string API_KEY = "d3c96f4f6bf27fd54e01d07c869d6b79";

        /// <summary>
        /// Url of REST api which gives json information about searched games
        /// </summary>
        private string GAME_URL = "https://api-v3.igdb.com/games";

        private readonly HttpClient httpClient;

        public ApiEngine()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<List<GameSearchResult>> GetSearchedGames(string searchedGame)
        {
            // Request message that will be sent to API endpoint
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, GAME_URL);

            string jsonPost = $"fields name; search \"{searchedGame}\";";

            // Adding Accept header to make sure that output will be json
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("user-key", API_KEY); // Add user-key to header

            // Added json body to request 
            request.Content = new StringContent(jsonPost, Encoding.UTF8, "application/json");

            // Request message is asynchronously posted
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Read json body of the response
            string jsonResponse = await response.Content.ReadAsStringAsync();

            List<GameSearchResult> gameResults = JsonConvert.DeserializeObject<List<GameSearchResult>>(jsonResponse);

            return gameResults;
        }

        /// <summary>
        /// Added new API query that will get all the information about current game
        /// </summary>
        public async Task<GameInformationModel> GetGame(GameSearchResult searchedGame)
        {
            // Request message that will be sent to API endpoint
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, GAME_URL);

            string jsonPost = $"fields *; where name = \"{searchedGame.Name}\";";

            // Adding Accept header to make sure that output will be json
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("user-key", API_KEY); // Add user-key to header

            // Added json body to request 
            request.Content = new StringContent(jsonPost, Encoding.UTF8, "application/json");

            // Request message is asynchronously posted
            HttpResponseMessage response = await httpClient.SendAsync(request);

            // Read json body of the response
            string jsonResponse = await response.Content.ReadAsStringAsync();

            List<GameInformationModel> games = JsonConvert.DeserializeObject<List<GameInformationModel>>(jsonResponse);

            return games[0];
        }
    }
}
