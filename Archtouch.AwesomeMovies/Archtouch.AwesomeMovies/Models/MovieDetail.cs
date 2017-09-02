using Newtonsoft.Json;

namespace Arctouch.AwesomeMovies.Models
{
    public class MovieDetail
    {
        [JsonProperty(PropertyName = "backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty(PropertyName = "genres")]
        public Genre[] Genres { get; set; }

        [JsonProperty(PropertyName = "homepage")]
        public string HomePage { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}
