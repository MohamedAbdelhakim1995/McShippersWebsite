using System.ComponentModel.DataAnnotations;

namespace McShippersWebsite.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }


    }
}
