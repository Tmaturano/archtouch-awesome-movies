using Arctouch.AwesomeMovies.Helpers;
using Arctouch.AwesomeMovies.Models;
using Arctouch.AwesomeMovies.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Arctouch.AwesomeMovies.ViewModels
{
    public class MoviesPageViewModel : BaseViewModel
    {
        #region Properties and variables
        private readonly IMovieDbApi _movieDbApi;
        private IPageDialogService _pageDialogService; //{ get; }
        private INavigationService _navigationService; // { get; }

        private const int DefaultQuantity = 20;
        private const int DefaultPage = 1;

        public int NextPage { get; private set; } = 1;

        private string _searchName;

        public string SearchName
        {
            get { return _searchName; }
            set { _searchName = value; }
        }

        public ObservableCollection<Result> Movies { get; private set; }

        #endregion

        #region Constructor

        public MoviesPageViewModel(INavigationService navigationService,
                                   IPageDialogService pageDialogService,
                                   IMovieDbApi movieDbApi)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _movieDbApi = movieDbApi;

            SearchCommand = new DelegateCommand(ExecuteSearchCommandAsync);
            SearchByNameCommand = new DelegateCommand(ExecuteSearchByNameCommandAsync);
            Movies = new ObservableCollection<Result>();
        }

        #endregion

        #region Commands

        public DelegateCommand SearchCommand { get; private set; }
        public DelegateCommand SearchByNameCommand { get; private set; }

        #endregion

        #region Methods

        private async Task SearchMovies()
        {
            try
            {
                IsBusy = true;

                var movies = await _movieDbApi.GetUpcomingMovies(NextPage);
                var genres = await _movieDbApi.GetGenres();

                if (movies == null)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "It was not possible to search the movies, please try again.", "Ok");
                    IsBusy = false;
                    return;
                }

                //TODO:
                //save the total_pages that come sfrom the api and store in Settings.TotalPages to check when loading more movies
                IEnumerable<string> genreNames;
                //Use AutoMap for this                
                foreach (var result in movies.Results)
                {

                    genreNames = from a in genres.Genres
                            join b in result.GenreIds
                            on a.id equals b.Value
                            select a.Name;
                    
                    Movies.Add(new Result
                    {
                        Adult = result.Adult,
                        BackdropPath = $"{Settings.BaseMovieDbImageUrl}/{Settings.MovieDbBackdropSizeOriginal}/{result.BackdropPath}",
                        GenreIds = result.GenreIds,
                        GenreNames = string.Join(", ", genreNames),
                        Id = result.Id,
                        OriginalLanguage = result.OriginalLanguage,
                        OriginalTitle = result.OriginalTitle,
                        Overview = result.Overview,
                        Popularity = result.Popularity,
                        PosterPath = $"{Settings.BaseMovieDbImageUrl}/{Settings.MovieDbPosterSizeMedium}/{result.PosterPath}",
                        ReleaseDate = result.ReleaseDate,
                        Title = result.Title,
                        Video = result.Video,
                        VoteAverage = result.VoteAverage,
                        VoteCount = result.VoteCount
                    });
                }
            }
            catch (Exception ex)
            {
                //Log the exception in somewhere    
                await _pageDialogService.DisplayAlertAsync("Error", "It was not possible to search the movies, please try again.", "Ok");
            }

            IsBusy = false;
        }

        private async void ExecuteSearchCommandAsync()
        {
            Movies.Clear();
            NextPage = 1;
            await SearchMovies();    
        }

        private async void ExecuteSearchByNameCommandAsync()
        {
            Movies.Clear();
            //Call api to search by name
        }

        public async Task LoadMoreMovies()
        {
            NextPage++;
            await SearchMovies();    
        }
        
        
        #endregion

    }
}
