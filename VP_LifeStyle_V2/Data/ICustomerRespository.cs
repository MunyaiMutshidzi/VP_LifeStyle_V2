
using VP_LifeStyle_V2.Data.DataAccess;
using VP_LifeStyle_V2.Models;
namespace VP_LifeStyle_V2.Data
{
    //Interface inherit IRespositoryBase<ClassName>
    public interface ICustomerRespository : IRespositoryBase<Customer>
    {
        Customer GetCustomerWithDetails(int id);
    }
}
