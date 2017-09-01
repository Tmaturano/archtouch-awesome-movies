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
        private IPageDialogService _pageDialogService; 
        private INavigationService _navigationService; 

        private const int DefaultQuantity = 20;
        private const int DefaultPage = 1;

        public int NextPage { get; private set; } = 1;
        public int NextPageByTitle { get; private set; } = 1;

        private string _searchName;

        public string SearchName
        {
            get { return _searchName; }
            set { _searchName = value; }
        }

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set => SetProperty(ref _isRefreshing, value);
        }

        public ObservableCollection<Result> Movies { get; private set; }


        private bool IsSearchNameEmpty => string.IsNullOrWhiteSpace(SearchName);

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
            RefreshCommand = new DelegateCommand(ExecuteRefreshCommandAsync);
            Movies = new ObservableCollection<Result>();
            IsRefreshing = false;
        }

        #endregion

        #region Commands

        public DelegateCommand SearchCommand { get; private set; }
        public DelegateCommand RefreshCommand { get; private set; }


        #endregion

        #region Methods

        #region Private
        private async Task SearchMovies(bool isRefreshing = false)
        {
            try
            {
                IsBusy = !isRefreshing;
                IsRefreshing = isRefreshing;

                if (!CheckInternetConnection())
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "Please check if you are connected to the Internet.", "Ok");
                    IsBusy = false;
                    IsRefreshing = IsBusy;
                    return;
                }

                var movies = IsSearchNameEmpty ? await _movieDbApi.GetUpcomingMovies(NextPage)
                            : await _movieDbApi.GetUpcomingMoviesByTitle(SearchName, NextPageByTitle);

                var genres = await _movieDbApi.GetGenres();

                if (movies == null)
                {
                    await _pageDialogService.DisplayAlertAsync("Error", "It was not possible to search the movies, please try again.", "Ok");
                    IsBusy = false;
                    IsRefreshing = IsBusy;
                    return;
                }
                
                if (movies.TotalPages > 0 && movies.TotalPages != Settings.TotalPages)
                    Settings.TotalPages = movies.TotalPages;

                IEnumerable<string> genreNames;

                //TODO:
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
            IsRefreshing = IsBusy;
        }

        private bool CheckIfTotalPagesReached()
        {
            if (Settings.TotalPages.Equals(0))
                return false;

            if (IsSearchNameEmpty && NextPage > Settings.TotalPages)
                return true;

            if (!IsSearchNameEmpty && NextPageByTitle > Settings.TotalPages)
                return true;

            return false;                
        }

        private void InitializeAndClearMoviesList()
        {
            Movies.Clear();

            if (IsSearchNameEmpty)
                NextPage = 1;
            else
                NextPageByTitle = 1;
        }

        private async void ExecuteSearchCommandAsync()
        {
            InitializeAndClearMoviesList();

            await SearchMovies();    
        }

        private async void ExecuteRefreshCommandAsync()
        {
            InitializeAndClearMoviesList();

            await SearchMovies(isRefreshing: true);
        }

        #endregion

        #region Public

        public async Task LoadMoreMovies()
        {
            if (CheckIfTotalPagesReached())
                return;

            if (IsSearchNameEmpty)
                NextPage++;
            else
                NextPageByTitle++;

            await SearchMovies();    
        }

        #endregion

        #endregion

    }
}
