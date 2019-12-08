using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.DataAccess
{
    public class MovieCompany
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
