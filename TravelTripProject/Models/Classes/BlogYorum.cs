using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class BlogYorum
    {
        public IEnumerable<Blog> Blog { get; set; }
        public IEnumerable<Yorumlar> Yorum { get; set; }
        public IEnumerable<Blog> Blog2 { get; set; }

    }
}