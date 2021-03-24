using System.ComponentModel.DataAnnotations;

namespace RoBHo_UserService.Request
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
