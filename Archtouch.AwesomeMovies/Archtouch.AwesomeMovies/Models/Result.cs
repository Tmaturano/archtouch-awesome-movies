﻿using Newtonsoft.Json;

namespace Arctouch.AwesomeMovies.Models
{
    public class Result
    {
        [JsonProperty(PropertyName = "vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "video")]
        public bool Video { get; set; }

        [JsonProperty(PropertyName = "vote_average")]
        public float VoteAverage { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "popularity")]
        public float Popularity { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty(PropertyName = "original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty(PropertyName = "original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty(PropertyName = "genre_ids")]
        public int?[] GenreIds { get; set; }

        [JsonProperty(PropertyName = "backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty(PropertyName = "adult")]
        public bool Adult { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }
    }
}
