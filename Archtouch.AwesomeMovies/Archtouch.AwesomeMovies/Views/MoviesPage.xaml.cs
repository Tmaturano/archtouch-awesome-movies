using Arctouch.AwesomeMovies.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Arctouch.AwesomeMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        public MoviesPage()
        {
            InitializeComponent();
        }

        private async void moviesList_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var movies = moviesList.ItemsSource as IList;

            if (movies.Count > 0 && e.Item == movies[movies.Count - 1])
            {
                await (BindingContext as MoviesPageViewModel).LoadMoreMovies(); 
            }
        }
    }
}