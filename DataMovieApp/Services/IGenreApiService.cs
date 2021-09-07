using DataMovieApp.Model;
using System.Threading.Tasks;

namespace DataMovieApp.Services
{
    public interface IGenreApiService
    {
        Task<Genres> GetGenres();
    }
}