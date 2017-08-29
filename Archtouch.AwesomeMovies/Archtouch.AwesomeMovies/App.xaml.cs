using Archtouch.AwesomeMovies.ViewModels;
using Archtouch.AwesomeMovies.Views;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Archtouch.AwesomeMovies
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
            //Container.RegisterTypeForNavigation<HomePage, HomePageViewModel>();
            //Container.RegisterTypeForNavigation<TalkDetailsPage, TalkDetailsPageViewModel>();

        }

    }
}
