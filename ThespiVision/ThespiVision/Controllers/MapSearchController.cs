using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using ThespiVision.Models;
using Xamarin.Forms.Maps;



//In a production version of this app this would be handled on a server. Due to time and resourse contraints this will be handled client side
namespace ThespiVision.Controllers
{
    class MapSearchController
    {


        private static readonly Geocoder _geocoder = new Geocoder();
        private static ObservableCollection<Show> showContainer = new ObservableCollection<Show> { }; // get shows
        private static List<Position> posList = new List<Position> { };

        //compare show positions to user position and return a list of show objects that are within the conrrect distance



        public static async Task<List<ShowsInRange>> getShowPosition(Position userLocation, int distance)
        {

            showContainer = ShowApiController.Get().Result;
            

            for(int j = 0; j < showContainer.Count; j++)
            {
                
                var carrier = await _geocoder.GetPositionsForAddressAsync(showContainer[j].location);
                posList.Add(new Position(carrier.First().Latitude, carrier.First().Longitude));

            }

            List<ShowsInRange> searchResult = new List<ShowsInRange> { };


            for (int i = 0; i < showContainer.Count; i++)
            {

                Position showPosition = posList[i];
                Console.WriteLine(Distance.BetweenPositions(showPosition, userLocation).Miles.ToString());
                if (Distance.BetweenPositions(showPosition, userLocation).Miles <= Distance.FromMiles(distance).Miles)
                {
                    searchResult.Add(new ShowsInRange(showContainer[i].showID, showContainer[i].title, showPosition, showContainer[i].company));

                }

            }
            return searchResult;
        }
    }
}
