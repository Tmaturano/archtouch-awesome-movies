using Newtonsoft.Json;

namespace Arctouch.AwesomeMovies.Models
{
    public class GenreResult
    {
        [JsonProperty(PropertyName = "genres")]
        public Genre[] Genres { get; set; }
    }
}
