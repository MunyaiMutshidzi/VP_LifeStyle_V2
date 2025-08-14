using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VP_LifeStyle_V2.Models;
namespace VP_LifeStyle_V2.Data
{
    public class LifeStyleIdentityDbContext : IdentityDbContext<AppUser> //Compulsory.
    {
        //Always include constructor
        public LifeStyleIdentityDbContext(DbContextOptions<LifeStyleIdentityDbContext> options) : base(options)
        {
        }

    }
}
