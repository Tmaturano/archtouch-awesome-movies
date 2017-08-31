using Arctouch.AwesomeMovies.Models;
using System.Threading.Tasks;

namespace Arctouch.AwesomeMovies.Services.Interfaces
{
    public interface IMovieDbApi
    {
        Task<MovieResult> GetUpcomingMovies();
        Task<GenreResult> GetGenres();
    }
}
