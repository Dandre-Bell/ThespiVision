using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ThespiVision.Views;

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
        }
    }
}
