using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.DataAccess
{
    public class MovieGenre
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
