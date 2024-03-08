using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.Requests
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Firstname is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required!")]
        public string SecondName { get; set; }
        [EmailAddress(ErrorMessage = "Please insert valid e-mail address!")]
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords should match!")]
        public string ConfirmPassword { get; set; }
    }
}
