﻿using System;
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

        public static List<ShowsInRange> FindShowsInRange(Position userLocation, int distance)
        {

            List<ShowsInRange> searchResult = new List<ShowsInRange> { };


            for (int i = 0; i < showContainer.Count; i++)
            {

                Position showPosition = posList[i];
                if (Distance.BetweenPositions(showPosition, userLocation).Equals(Distance.FromMiles(distance)))
                {
                    searchResult.Add(new ShowsInRange(showContainer[i].showID, showContainer[i].title, showPosition, showContainer[i].company));
                    Console.WriteLine("Result added");
                }

            }

            return searchResult;
        }

        public static async void getShowPosition(Position userLocation, int distance)
        {
            Console.WriteLine("HIT");
            Console.WriteLine("Filling showContainer");
            showContainer = ShowApiController.Get().Result;
            Console.WriteLine("showContainer Filled");
            

            for(int j = 0; j < showContainer.Count; j++)
            {
                
                var carrier = await _geocoder.GetPositionsForAddressAsync("Krebs Hall, Johnstown, Pennsylvania");
                posList.Add(new Position(carrier.First().Latitude, carrier.First().Longitude));
                Console.WriteLine("Position added");
                Console.WriteLine(posList.Count);
                Console.WriteLine(posList[0].Latitude);
            }

            List<ShowsInRange> searchResult = new List<ShowsInRange> { };


            for (int i = 0; i < showContainer.Count; i++)
            {

                Position showPosition = posList[i];
                if (double.Parse(Distance.BetweenPositions(showPosition, userLocation).ToString()) <= double.Parse((Distance.FromMiles(distance)).ToString()))
                {
                    searchResult.Add(new ShowsInRange(showContainer[i].showID, showContainer[i].title, showPosition, showContainer[i].company));
                    Console.WriteLine("Result added");
                }

            }
        }
    }
}