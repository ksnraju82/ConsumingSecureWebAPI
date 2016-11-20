using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebAPIUsingSecureToken.Models
{
    public class Movie
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }        
    }
}