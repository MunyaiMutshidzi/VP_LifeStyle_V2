using Microsoft.Identity.Client;
using VP_Lifestyle.Data;
using VP_LifeStyle_V2.Models;

namespace VP_LifeStyle_V2.Data
{
    //Inherit from the Respositorybase and IReservationRespository
    public class ReservationRespository :RespositoryBase<Reservation> ,IReservationRespository
    {
       //no private readonly variable

        //Create constructor
       public ReservationRespository(LifestyleDbContext lifestyleDbContext)
             :base(lifestyleDbContext) 
        {

        }
    }
}
