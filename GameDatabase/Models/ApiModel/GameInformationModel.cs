using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase.Models.ApiModel
{
    public class GameInformationModel
    {
        public int Id { get; set; }

        [JsonProperty("age_ratings")]
        public IList<int> AgeRatings { get; set; }

        [JsonProperty("aggregated_rating")]
        public double AggregatedRating { get; set; }

        [JsonProperty("aggregated_rating_count")]
        public int AggregatedRatingCount { get; set; }

        [JsonProperty("alternative_names")]
        public List<int> alternative_names { get; set; }
        public List<int> artworks { get; set; }
        public List<int> bundles { get; set; }

        public int category { get; set; }
        public int collection { get; set; }
        public int cover { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }
        public List<int> expansions { get; set; }
        public List<int> external_games { get; set; }

        [JsonProperty("first_release_date")]
        public int FirstReleaseDate { get; set; }
        public int franchise { get; set; }
        public List<int> franchises { get; set; }
        public List<int> game_engines { get; set; }
        public List<int> game_modes { get; set; }
        public List<int> genres { get; set; }
        public int hypes { get; set; }
        public List<int> involved_companies { get; set; }
        public List<int> keywords { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        public List<int> platforms { get; set; }
        public List<int> player_perspectives { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }
        public int pulse_count { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("rating_count")]
        public int RatingCount { get; set; }
        public List<int> release_dates { get; set; }
        public List<int> screenshots { get; set; }
        public List<int> similar_games { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("storyline")]
        public string Storyline { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
        public List<int> tags { get; set; }
        public List<int> themes { get; set; }

        [JsonProperty("time_to_beat")]
        public int TimeToBeat { get; set; }

        [JsonProperty("total_rating")]
        public double TotalRating { get; set; }

        [JsonProperty("total_rating_count")]
        public int TotalRatingCount { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
        public IList<int> videos { get; set; }
        public IList<int> websites { get; set; }

        public string RatingApi
        {
            get
            {
                return $"{Math.Round(TotalRating, 2)} by {TotalRatingCount} raters.";
            }
        }
    }
}
