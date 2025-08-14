using VP_Lifestyle.Models;

namespace VP_LifeStyle_V2.Models
{
    public enum TableType
    {
        Solo, Couple, Family
    }

    public class Reservation
    {
      public int ReservationID { get; set; }
      public int CustomerID{ get; set; }//Database relationship[Foreign key]
      public int ProductID {  get; set; }//Database relationship [Foreign key]
      public string ReservationName { get; set; }
      public TableType TableType { get; set; }

      public Customer Customer { get; set; }//Database relationship
      public Product Product { get; set; }//Database Relationship
    }
}