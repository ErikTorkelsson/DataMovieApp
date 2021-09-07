using DataMovieApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataMovieApp.Services
{
    public class GenreApiService : IGenreApiService
    {
        public async Task<Genres> GetGenres()
        {
            using (HttpClient client = new HttpClient())
            {
                string uri = "https://api.themoviedb.org/3/genre/movie/list?api_key=b856829afbcdd6bd2f38f041b3bec53e&language=en-US";
                HttpResponseMessage response = await client.GetAsync(uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var genres = JsonConvert.DeserializeObject<Genres>(jsonResponse);
                return genres;
            }
        }
    }
}
