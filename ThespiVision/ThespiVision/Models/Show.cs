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
        public DateTime openDate { get; set; }
        public DateTime closeDate { get; set; }
        public string description { get; set; }
        public Guid showID { get; set; }

        public Show(string title, string company, string location, string description, DateTime openDate, DateTime closeDate)
        {
            this.title = title;
            this.company = company;
            this.location = location;
            this.openDate = openDate;
            this.closeDate = closeDate;
            this.description = description;
            showID = Guid.NewGuid();
        }
    }
}
