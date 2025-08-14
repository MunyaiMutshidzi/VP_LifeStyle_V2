using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using VP_LifeStyle_V2.Models;

namespace VP_LifeStyle_V2.Infrastructure
{
    public class CustomValidator : IPasswordValidator<AppUser>
    {
       
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
          
            if((user.Email.EndsWith("gmail.com") || user.Email.EndsWith("gmail.co.za") || 
                user.Email.EndsWith("restoran.com")))
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "EmailDomainError",
                    Description = "Email address"
                }));

            }
        }
    }
}
