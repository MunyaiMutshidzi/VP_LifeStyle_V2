using Microsoft.EntityFrameworkCore;
using VP_Lifestyle.Data;
using VP_LifeStyle_V2.Models;

namespace VP_LifeStyle_V2.Data
{
    public class CustomerRespository : RespositoryBase<Customer>, ICustomerRespository
    {

        public CustomerRespository(LifestyleDbContext lifestyleDbContext) :
                                  base(lifestyleDbContext)
        {

        }
        //Important
        public Customer GetCustomerWithDetails(int id)
        {
            return _lifestyleDbContext.Customers
                  .Include(c => c.Reservations)
                  .ThenInclude(c => c.Product)
                  .FirstOrDefault(c => c.CustomerID == id);
        }
    }
}
