using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ThespiVision.Views;
using ThespiVision.Controllers;

namespace ThespiVision
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(LogInPage), typeof(LogInPage));
            Routing.RegisterRoute(nameof(PostShowPage), typeof(PostShowPage));
            Routing.RegisterRoute(nameof(SavedShowsPage), typeof(SavedShowsPage));

            SavedShowsTab.IsVisible = LoginController.loggedIn;
            PostShowTab.IsVisible = LoginController.loggedIn;

            LogInPage.LoginStatusChanged += UpdateFlyout;

        }

        private void LogOut(object sender, EventArgs args)
        {
            LoginController.loggedIn = false;
            UpdateFlyout(this, EventArgs.Empty);
        }

        private void UpdateFlyout(object sender, EventArgs args)
        {
            SavedShowsTab.IsVisible = LoginController.loggedIn;
            PostShowTab.IsVisible = LoginController.loggedIn;
            LoginTab.IsVisible = !LoginController.loggedIn;
            
        }
    }
}
