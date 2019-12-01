using MovieStore.DTO.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.DataTransfer.Objects
{
    public class UserLoginDTO
    {
        [Required]
        [StringLength(ValidationRules.USERNAME_MAX_LENGTH)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
