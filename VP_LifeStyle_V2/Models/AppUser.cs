using Microsoft.AspNetCore.Identity;

namespace VP_LifeStyle_V2.Models
{
    public class AppUser : IdentityUser
    {
        public byte[] AvatarImageData { get; set; }
    }
}
