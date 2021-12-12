using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ThespiVision.Models;
using ThespiVision.Controllers;

namespace ThespiVision.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedShowsPage : ContentPage
    {


        private static ObservableCollection<Show> _savedShows = new ObservableCollection<Show> { };

        public SavedShowsPage()
        {
            InitializeComponent();
            _savedShows = ShowApiController.Get().Result;
            EmptySaveListText.IsVisible = !(_savedShows.Count > 0);
            SavedShowListView.IsVisible = _savedShows.Count > 0;
            _savedShows.CollectionChanged += UpdateVisibility;
            SavedShowListView.ItemsSource = _savedShows;
            SavedShowListView.ItemTapped += openDetailPage;
        }

        override
         protected void OnAppearing()
        {
            _savedShows = ShowApiController.Get().Result;
            SavedShowListView.ItemsSource = _savedShows;
            UpdateVisibility(this, EventArgs.Empty);

        }

        private async void openDetailPage(object sender, EventArgs args)
        {
            var chosenShow = SavedShowListView.SelectedItem as Show;
           await Navigation.PushAsync(new SavedShowDetailPage(chosenShow.title, chosenShow.company, chosenShow.description, chosenShow.openDate, chosenShow.closeDate, chosenShow.showID));
        }

        private void UpdateVisibility(object sender, EventArgs args)
        {
            EmptySaveListText.IsVisible = !(_savedShows.Count > 0);
            SavedShowListView.IsVisible = _savedShows.Count > 0;
        }

    }
}