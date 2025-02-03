using System.ComponentModel.DataAnnotations;

namespace API.Dtos.IdentityDto
{
    public class RegisterDto
    {
        [Required]
        public string FirtsName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
