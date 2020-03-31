using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeezyBackend.Web.Models
{
    public class CommonRecommendationProperties
    {
       
        public string Title { get; set; }
       
        public string Overview { get; set; }
  
        public string Genre { get; set; }
  
        public string Language { get; set; }
  
        public DateTime ReleaseDate { get; set; }
   
        public string WebSite { get; set; }
   
        public string AssociatedKeywords { get; set; }
    }
}
