using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.DataAccess
{
    public class MovieRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        [Required]
        public int Rate { get; set; }
    }
}
