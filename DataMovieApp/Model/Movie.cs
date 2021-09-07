using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMovieApp.Model
{
    public class Movie
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        private string posterPath;
        [JsonProperty("poster_path")]
        public string PosterPath
        {
            get { return posterPath; }
            set { posterPath = $"https://image.tmdb.org/t/p/original{value}"; }
        }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("vote_average")]
        public string VoteAverage { get; set; }

    }
}
