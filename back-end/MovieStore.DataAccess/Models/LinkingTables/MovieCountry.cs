using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.DataAccess
{
    public class MovieCountry
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
