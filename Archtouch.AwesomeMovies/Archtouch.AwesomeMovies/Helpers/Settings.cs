// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Collections;
using System.Collections.Generic;

namespace Arctouch.AwesomeMovies.Helpers
{
	public static class Settings
	{
        private static ISettings AppSettings => CrossSettings.Current;

        public static string BaseMovieDbUrl => "https://api.themoviedb.org/3/";
        public static string BaseMovieDbImageUrl => "https://image.tmdb.org/t/p/";
        public static string MovieDbApiKey => "1f54bd990f1cdfb230adb312546d765d";

        public static string MovieDbPosterSizeSmall => "w92";
        public static string MovieDbPosterSizeMedium => "w154";
        public static string MovieDbPosterSizeBig => "w185";
        public static string MovieDbPosterSizeOriginal => "original";
        public static string MovieDbBackdropSizeSmall => "w300";
        public static string MovieDbBackdropSizeMedium => "w780";
        public static string MovieDbBackdropSizeBig => "w1280";
        public static string MovieDbBackdropSizeOriginal => "original";
    }
}