using System.ComponentModel; //used to provide the DisplayName property
using System.ComponentModel.DataAnnotations;
using VP_Lifestyle.Models;//used to provide the required property
namespace VP_LifeStyle_V2.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [DisplayName("First name")]
        [Required(ErrorMessage ="Enter a first name")]
        public string CustomerFirstName { get; set; }   //Property name should remain constant [sort&filter]

        [DisplayName("Last name")]
        [Required(ErrorMessage ="Enter a last name")]
        public string CustomerLastName { get; set; }   //Property name should remain constant [sort&filter]

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Missing @gmail")]
        [Required(ErrorMessage ="Enter an email")]
        public string CustomerEmail {  get; set; }

        
        [Required]
        public DateTime     Registration { get; set; }

        public ICollection<Reservation> Reservations { get; set; } //Database relationship
    }
}
