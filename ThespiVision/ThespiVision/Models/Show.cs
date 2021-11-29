using System;
using System.Collections.Generic;
using System.Text;

namespace ThespiVision.Models
{
    public class Show
    {
        public string title { get; set; }
        public string company { get; set; }
        public string location { get; set; }
        public DateTime showDate { get; set; }
        public string description { get; set; }

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
