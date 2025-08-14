using Microsoft.AspNetCore.Mvc;
using VP_Lifestyle.Data;
using VP_LifeStyle_V2.Data;

namespace VP_LifeStyle_V2.Controllers
{
    public class RegisteredCustomer : Controller
    {
        private LifeStyleIdentityDbContext LifeStyleIdentityDbContext;
        private LifestyleDbContext LifestyleDbContext;

        public RegisteredCustomer(LifeStyleIdentityDbContext lifeStyleIdentityDbContext, LifestyleDbContext lifestyleDbContext)
        {
            LifeStyleIdentityDbContext = lifeStyleIdentityDbContext;
            LifestyleDbContext = lifestyleDbContext;
        }
    
        //public IActionResult Index(string role="Customer")
        //{
        //    var Customers = LifeStyleIdentityDbContext.Users.FirstOrDefault(x => x.)
        //}
    }
}
