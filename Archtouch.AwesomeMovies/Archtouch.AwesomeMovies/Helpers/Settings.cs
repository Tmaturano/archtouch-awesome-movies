// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Arctouch.AwesomeMovies.Helpers
{
	public static class Settings
	{
        private static ISettings AppSettings => CrossSettings.Current;

        public static string BaseMovieDbUrl => "https://api.themoviedb.org/3/";

        public static string MovieDbApiKey => "1f54bd990f1cdfb230adb312546d765d";
       
    }
}