using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace ThespiVision.Models
{
    public class ShowsInRange
    {
        public Guid showID;
        public string title;
        public Position showLocation;
        public string company;

        public ShowsInRange(Guid showID, string title, Position showLocation, string company)
        {
            this.showID = showID;
            this.title = title;
            this.showLocation = showLocation;
            this.company = company;
        }
    }
}
