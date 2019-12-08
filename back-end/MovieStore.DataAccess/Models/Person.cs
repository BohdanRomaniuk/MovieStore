using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieStore.DataAccess
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public List<MovieActor> ActingInMovies { get; set; }
        public List<Movie> DirectingMovies { get; set; }
    }
}
