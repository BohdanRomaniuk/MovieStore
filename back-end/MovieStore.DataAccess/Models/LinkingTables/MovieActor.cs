using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.DataAccess
{
    public class MovieActor
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
