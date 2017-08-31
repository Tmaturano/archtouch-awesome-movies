using Arctouch.AwesomeMovies.Services;
using Arctouch.AwesomeMovies.Services.Interfaces;
using Arctouch.AwesomeMovies.ViewModels;
using Arctouch.AwesomeMovies.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Arctouch.AwesomeMovies
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : PrismApplication
    {
        public App() { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            // INICIANDO NAVEGAÇÃO POR URI
            //NavigationService.NavigateAsync(new Uri("http://www.myapp.com/MainPage", UriKind.Absolute));

            // INICIANDO NAVEGAÇÃO POR STRING -- MAGIC STRINGS --
            NavigationService.NavigateAsync("NavigationPage/MoviesPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MoviesPage, MoviesPageViewModel>();
            Container.RegisterType(typeof(IMovieDbApi), typeof(MovieDbApi), null, new PerThreadLifetimeManager());
            //Container.RegisterTypeForNavigation<HomePage, HomePageViewModel>();
            //Container.RegisterTypeForNavigation<TalkDetailsPage, TalkDetailsPageViewModel>();

        }

    }
}
