﻿using Newtonsoft.Json;

namespace Arctouch.AwesomeMovies.Models
{
    public class Dates
    {
        [JsonProperty(PropertyName = "maximum")]
        public string maximum { get; set; }

        [JsonProperty(PropertyName = "minimum")]
        public string minimum { get; set; }
    }
}
