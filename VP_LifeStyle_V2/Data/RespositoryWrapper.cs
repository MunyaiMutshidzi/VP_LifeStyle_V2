using VP_Lifestyle.Data;
using VP_LifeStyle_V2.Models;

namespace VP_LifeStyle_V2.Data
{
    public class RespositoryWrapper : IRespositoryWrapper
    {
        //Defining the I Wrapper variable and method

        //step 1: create a read only DBconteext
        private readonly LifestyleDbContext _lifeStyleDbContext;
        //Step 2: Create IResopisitory variable for each data type
        private ICustomerRespository _customer;
        private IReservationRespository _reservation;

        //Create a constructor
        public RespositoryWrapper(LifestyleDbContext lifestyleDbContext)
        {
            _lifeStyleDbContext = lifestyleDbContext;
        }

        public ICustomerRespository Customer
        {
            get
            {
                if(_customer == null)
                {
                    //link with CustomerResposiroye
                    _customer = new CustomerRespository(_lifeStyleDbContext);
                }
                return _customer;
            }
            
        }
        public IReservationRespository Reservation
        {
            get
            {
                if(_reservation == null)
                {
                    _reservation = new ReservationRespository(_lifeStyleDbContext);
                }
                return _reservation;
            }
            
            
        }

        public void Save()
        {
            _lifeStyleDbContext.SaveChanges();
        }
    }
}
