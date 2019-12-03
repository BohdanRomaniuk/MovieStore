using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.DataAccess
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UkrName { get; set; }

        [Required]
        public string OriginName { get; set; }

        [Required]
        public string Poster { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Story { get; set; }

        [Required]
        public string Length { get; set; }

        [Required]
        public string Companies { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Actors { get; set; }

        [Required]
        public double Price { get; set; }

        public List<Comment> Comments { get; set; }

        public List<MovieRate> MovieRates { get; set; }

        public Movie()
        {
        }

        public Movie(string ukr, string org, string poster, int year, string genre, string country,
            string length, string companies, string director, string actors)
        {
            UkrName = ukr;
            OriginName = org;
            Poster = poster;
            Year = year;
            Genre = genre;
            Country = country;
            Length = length;
            Companies = companies;
            Director = director;
            Actors = actors;
        }
    }
}
