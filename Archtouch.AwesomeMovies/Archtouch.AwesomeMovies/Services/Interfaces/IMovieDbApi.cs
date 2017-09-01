using Arctouch.AwesomeMovies.Models;
using System.Threading.Tasks;

namespace Arctouch.AwesomeMovies.Services.Interfaces
{
    public interface IMovieDbApi
    {
        Task<MovieResult> GetUpcomingMovies(int page);
        Task<MovieResult> GetUpcomingMoviesByTitle(string searchName, int page);
        Task<GenreResult> GetGenres();
    }
}
