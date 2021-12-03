using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ThespiVision
{
    public partial class App : Application
    {
        public App()
        {
            var status = Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            InitializeComponent();
            MainPage = new AppShell();
            Console.WriteLine(status);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
