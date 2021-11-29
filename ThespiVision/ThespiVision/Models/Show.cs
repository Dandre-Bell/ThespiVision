using System;
using System.Collections.Generic;
using System.Text;

namespace ThespiVision.Models
{
    public class Show
    {
        private string title { get; set; }
        private string company { get; set; }
        private string location { get; set; }
        private DateTime showDate { get; set; }
        private string description { get; set; }

        public Show(string title, string company, string location, string description)
        {
            this.title = title;
            this.company = company;
            this.location = location;
            // this.showDate = showDate;
            this.description = description;
        }
    }
}
