using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyBackend.Repository.Data
{
    
        public class GenreDetails
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class GenreDBJson
        {
            public List<GenreDetails> genres { get; set; }
        }
    
}
