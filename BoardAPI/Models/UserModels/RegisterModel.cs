using System.ComponentModel.DataAnnotations;

namespace BoardAPI.Models.UserModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password needs to have at least 6 characters.")]
        public string Password { get; set; }
    }
}
