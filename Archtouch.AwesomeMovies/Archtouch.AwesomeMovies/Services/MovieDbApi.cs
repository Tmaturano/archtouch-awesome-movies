using System.Threading.Tasks;
using Arctouch.AwesomeMovies.Models;
using Arctouch.AwesomeMovies.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using Arctouch.AwesomeMovies.Helpers;

namespace Arctouch.AwesomeMovies.Services
{
    public class MovieDbApi : IMovieDbApi
    {
        private readonly HttpClient _httpClient;

        public MovieDbApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<GenreResult> GetGenres()
        {
            var response = await _httpClient.GetAsync($"{Settings.BaseMovieDbUrl}genre/movie/list?api_key={Settings.MovieDbApiKey}").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<GenreResult>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

        public async Task<MovieResult> GetUpcomingMovies(int page)
        {
            var response = await _httpClient.GetAsync($"{Settings.BaseMovieDbUrl}movie/upcoming?api_key={Settings.MovieDbApiKey}&page={page}").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<MovieResult>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }
    }
}
