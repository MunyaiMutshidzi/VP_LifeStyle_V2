using System.ComponentModel.DataAnnotations;

namespace VP_LifeStyle_V2.Models.ProductMenuViewModel
{
    public class CreateUserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
