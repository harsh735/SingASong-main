using System.ComponentModel.DataAnnotations;

namespace SingASongAPI.Models
{
    public class Login
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string userEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string userPassword { get; set; }


    }
}
