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
    public partial class PostShowPage : ContentPage
    {
        public PostShowPage()
        {
            InitializeComponent();
            
        }


        public async void PostShow(object sender, EventArgs args)
        {
          await ShowApiController.Post(title.Text, company.Text, location.Text, desctiption.Text, open.Date, close.Date);
        }
    }
}