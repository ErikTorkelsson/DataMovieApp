using DataMovieApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataMovieApp.Services
{
    class MoviesApiService : IMoviesApiService
    {
        public async Task<Movies> GetMovies(int genreId)
        {
            using (HttpClient client = new HttpClient())
            {
                string uri = $"https://api.themoviedb.org/3/discover/movie?api_key=b856829afbcdd6bd2f38f041b3bec53e&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=&with_genres={genreId}&with_watch_monetization_types=flatrate";
                HttpResponseMessage response = await client.GetAsync(uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var movies = JsonConvert.DeserializeObject<Movies>(jsonResponse);
                return movies;
            }

        }
    }
}
