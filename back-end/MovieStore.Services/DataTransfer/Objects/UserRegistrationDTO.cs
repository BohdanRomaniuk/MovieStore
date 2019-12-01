using MovieStore.DTO.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.DataTransfer.Objects
{
    public class UserRegistrationDTO
    {
        [Required]
        [StringLength(ValidationRules.USERNAME_MAX_LENGTH),
         RegularExpression(ValidationRules.ONLY_LETTERS_AND_NUMBERS)]
        public string UserName { get; set; }

        [Required]
        [StringLength(ValidationRules.USERNAME_MAX_LENGTH)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(ValidationRules.USERNAME_MAX_LENGTH)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
