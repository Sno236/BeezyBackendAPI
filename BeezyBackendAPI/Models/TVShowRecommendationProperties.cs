using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeezyBackend.Web.Models
{
    public class TVShowRecommendationProperties : CommonRecommendationProperties
    {
        
        public int NumberOfSeasons { get; set; }
        
        public int NumberOfEpisodes { get; set; }
        
        public bool IsConcluded { get; set; }
    }
}
