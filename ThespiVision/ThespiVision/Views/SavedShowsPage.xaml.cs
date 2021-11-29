using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ThespiVision.Models;

namespace ThespiVision.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedShowsPage : ContentPage
    {
        private readonly ObservableCollection<Show> _savedShows = new ObservableCollection<Show> { };

        public SavedShowsPage()
        {
            InitializeComponent();

            EmptySaveListText.IsVisible = !(_savedShows.Count > 0);

            SavedShowListView.ItemsSource = _savedShows;
            
        }

        private async void testAdd(object sender, EventArgs args)
        {
           _savedShows.Add(new Show("Test Show", "Shakespear", "Right here", "It's a test show"));
            Console.WriteLine(_savedShows.Count);
        }
    }
}