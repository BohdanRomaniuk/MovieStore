using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.DataAccess
{
    public class MovieOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        [Required]
        public int UserId { get; set; }

        [JsonIgnore]
        public Movie Movie { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}
