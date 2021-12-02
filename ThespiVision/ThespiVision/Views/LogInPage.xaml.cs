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
    public partial class LogInPage : ContentPage
    {
        public static event EventHandler LoginStatusChanged;

        public LogInPage()
        {
            InitializeComponent();
        }

        private void SendLoginRequest(object sender, EventArgs e)
        {
            LoginController.loggedIn = true;
            LoginStatusChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}