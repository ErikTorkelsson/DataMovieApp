using DataMovieApp.Model;
using System.Threading.Tasks;

namespace DataMovieApp.Services
{
    public interface IMoviesApiService
    {
        Task<Movies> GetMovies(int genreId);
    }
}