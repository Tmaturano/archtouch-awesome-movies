using Newtonsoft.Json;

namespace Arctouch.AwesomeMovies.Models
{
    public class Genre
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
