using VP_LifeStyle_V2.Models;

namespace VP_LifeStyle_V2.Data
{
    public interface IRespositoryWrapper
    {
        //Only create variable of the class and a method that would be used 
        //Most through out the application, Interface of the respository
        public ICustomerRespository Customer { get; }
        public IReservationRespository Reservation { get; }

        public void Save();
    }
}
