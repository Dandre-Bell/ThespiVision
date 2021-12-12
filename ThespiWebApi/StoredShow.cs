using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThespiWebApi
{
    public class StoredShow
    {
        public string title { get; set; }
        public string company { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public DateTime showDate { get; set; }
        public Guid showID { get; set; }


    }
}
