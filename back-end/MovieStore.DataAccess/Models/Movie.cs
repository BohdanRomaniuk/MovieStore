using Newtonsoft.Json;
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

        [JsonIgnore]
        public List<MovieGenre> Genres { get; set; }
        //public int GenreId { get; set; }

        [JsonIgnore]
        public List<MovieCountry> Countries { get; set; }
        //public int CountryId { get; set; }

        [Required]
        public string Story { get; set; }

        [Required]
        public string Length { get; set; }

        public List<MovieCompany> Companies { get; set; }

        public Person Director { get; set; }
        public int DirectorId { get; set; }

        public List<MovieActor> Actors { get; set; }

        [Required]
        public double Price { get; set; }

        public List<Comment> Comments { get; set; }

        public List<MovieRate> MovieRates { get; set; }

        public Movie()
        {
        }

        public Movie(string ukr, string org, string poster, int year, List<Genre> genres, List<Country> countries,
            string length, string companies, string director, string actors)
        {
            UkrName = ukr;
            OriginName = org;
            Poster = poster;
            Year = year;
            //MovieGenres = genres;
            //Countries = countries;
            Length = length;
            //Companies = companies;
            //Director = director;
            //Actors = actors;
        }
    }
}
