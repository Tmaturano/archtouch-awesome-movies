using Arctouch.AwesomeMovies.Models;
using Prism.Navigation;

namespace Arctouch.AwesomeMovies.ViewModels
{
    public class MovieDetailPageViewModel : BaseViewModel
    {
        private Result _movieDetail;

        public Result MovieDetail
        {
            get { return _movieDetail; }
            set
            {
                SetProperty(ref _movieDetail, value);
            }
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("MovieDetail"))
                MovieDetail = parameters["MovieDetail"] as Result;            
        }

    }
}
