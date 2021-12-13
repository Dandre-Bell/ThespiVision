using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using ThespiVision.Models;
using ThespiVision.Controllers;

namespace ThespiVision.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        // Create a list of objects contraining the showID,Titles, and generated positions for shows returned from the server
        public HomePage()
        {
            InitializeComponent();
            RadiusSlider.Value = 20;

            GoToUser(this, EventArgs.Empty);
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs args)
        {
            RadiusDisplay.Text = "Shows within " + Math.Floor(RadiusSlider.Value) + " miles";
        }

        private async void GoToUser(object sender, EventArgs args)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    showMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(1)));
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        private async void FindShows(object sender, EventArgs args)
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            
            Console.WriteLine("finding shows");
            //Run server side search code
            MapSearchController.getShowPosition(new Position(location.Latitude, location.Longitude), (int)RadiusSlider.Value);
            ///List<ShowsInRange> foundShows = MapSearchController.FindShowsInRange(new Position(location.Latitude, location.Longitude), (int)RadiusSlider.Value);
            /*
            Console.WriteLine("Found shows");
            // replace tempArr with new list
            foreach(ShowsInRange foundShow in foundShows)
            {
                showMap.Pins.Add(new Pin
                {
                    Label = foundShow.title,
                    Address = foundShow.company,
                    Position = foundShow.showLocation,
                    Type = PinType.Place
                });
            }           
      */
            
        }

    }
}