using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VP_LifeStyle_V2.Models; //Enable the use of a database

namespace VP_LifeStyle_V2.Data
{
    public class SeedIdentityData
    {
        public class UserModel
        {
            //
            public string UserName {  get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }

        private static readonly List<UserModel> SeedUsers = new()
        {
            //Testing
          new UserModel {UserName="Admin", Role="Admin", Email="Admin@restoran.com", Password="Secret123$"}
        };

        public static async void SeedIdentity(IApplicationBuilder app)
        {
            LifeStyleIdentityDbContext context = app.ApplicationServices.
                                                 CreateScope().ServiceProvider.GetRequiredService<LifeStyleIdentityDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //Initialize a UserManager and RoleManager

            //1st UserManager - provides APIs manage user details e.g Username,password,email and etc
            UserManager<AppUser> UserManager = app.ApplicationServices
                                                    .CreateScope().ServiceProvider
                                                    .GetRequiredService<UserManager<AppUser>>();
            //2nd RoleManager - Provides APIs to manage the roles e.g staff,admin/customer and ect
            RoleManager<IdentityRole> RoleManager = app.ApplicationServices
                                                    .CreateScope().ServiceProvider
                                                    .GetRequiredService<RoleManager<IdentityRole>>();   
            foreach (var user in SeedUsers)
            {
                if (await UserManager.FindByNameAsync(user.UserName) == null)
                {
                    if (await RoleManager.FindByNameAsync(user.Role) == null)
                    {
                        await RoleManager.CreateAsync(new IdentityRole(user.Role));
                    }

                    AppUser identityUser = new AppUser
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                    };

                    IdentityResult result = await UserManager.CreateAsync(identityUser, user.Password);

                    if(result.Succeeded)
                    {
                       await UserManager.AddToRoleAsync(identityUser,user.Role);
                    }
                }     
            } 
        }
    }
}
