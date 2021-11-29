using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThespiVision.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedShowsPage : ContentPage
    {
        private ObservableCollection<string> SavedShows = new ObservableCollection<string>
        {
            "Show 1",
            "Show 2",
            "Show 3"
        };



        public SavedShowsPage()
        {
            InitializeComponent();

            EmptySaveListText.IsVisible = !(SavedShows.Count > 0);

            SavedShowListView.ItemsSource = SavedShows;
            
        }
    }
}