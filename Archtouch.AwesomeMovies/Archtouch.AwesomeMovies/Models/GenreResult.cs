using Newtonsoft.Json;

namespace Archtouch.AwesomeMovies.Models
{
    public class GenreResult
    {
        [JsonProperty(PropertyName = "genres")]
        public Genre[] Genres { get; set; }
    }
}
