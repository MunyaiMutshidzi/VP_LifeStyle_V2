using System.ComponentModel.DataAnnotations;
using System.Net;

namespace VP_LifeStyle_V2.Models.Viewmodels
{
    public class LoginView
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [UIHint("password")] //specifies that the UI attribute will retrieve a data of
                             //type="password"  e.g <input type="password" /> in HTML
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";//Returns the application to the home page

        public bool RemeberMe { get;set; }// is enable when the user clicks the remember me box.
    }
}
