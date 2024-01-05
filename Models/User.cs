using System.ComponentModel.DataAnnotations;

namespace RegisterLoginApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Email name is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6,ErrorMessage ="Password vmust be atleast 6 characters")]
        public string Password { get; set; }
    }
}
