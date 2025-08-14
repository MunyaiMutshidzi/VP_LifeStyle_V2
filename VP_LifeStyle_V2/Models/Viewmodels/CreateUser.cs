using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VP_LifeStyle_V2.Models.Viewmodels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class Register
    {
        [Required(ErrorMessage = "Please enter your Full names")]
        [DisplayName("Full Name")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Please enter your Username")]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        public string ReturnUrl { get; set; } = "/"; // Returns the application to the home page

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)] // Important
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public IFormFile AvatarImage { get; set; } // Upload/retrieve avatar
    }

}
