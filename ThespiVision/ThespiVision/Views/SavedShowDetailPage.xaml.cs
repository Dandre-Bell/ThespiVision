using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ThespiVision.Controllers;

namespace ThespiVision.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedShowDetailPage : ContentPage
    {
        private Guid itemId;
        public SavedShowDetailPage(string showTitle, string showCompany, string showDescription, DateTime showOpen, DateTime showClose, Guid showID)
        {
            InitializeComponent();
            Title.Text = showTitle;
            Company.Text = showCompany;
            OpenDate.Text = showOpen.ToString();
            CloseDate.Text = showClose.ToString();
            Description.Text = showDescription;
            itemId = showID;
        }

        private async void DeleteEntry(object sender, EventArgs args)
        {
            if(ShowApiController.Delete(itemId).Result)
            {
               await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Delete failed", "Could not delete item", "Ok");
            }
            

        }
    }
}