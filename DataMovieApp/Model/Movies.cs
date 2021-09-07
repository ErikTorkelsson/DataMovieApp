using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataMovieApp.Model
{
    public class Movies
    {
        [JsonProperty("results")]
        public List<Movie> movies { get; set; }
        public int count { get; set; }
    }
}
