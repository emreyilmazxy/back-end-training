using System.ComponentModel.DataAnnotations;

namespace Identity.Dtos.auth
{
    public class LoginDto
    {
        public string UserNamee { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
