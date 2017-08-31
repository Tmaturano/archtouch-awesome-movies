using Newtonsoft.Json;

namespace Archtouch.AwesomeMovies.Models
{
    public class MovieResult
    {
        [JsonProperty(PropertyName = "results")]
        public Result[] Results { get; set; }

        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }

        [JsonProperty(PropertyName = "dates")]
        public Dates Dates { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
    }
}
