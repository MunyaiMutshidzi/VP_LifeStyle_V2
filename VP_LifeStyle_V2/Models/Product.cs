
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VP_Lifestyle.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [DisplayName("Product name")]
        [Required(ErrorMessage ="Fill in the Product Name.")]
        public string ProductName { get; set; }

        [DisplayName("Product Code")]
        [Required(ErrorMessage ="Fill in the Product Code.")]
        public string ProductCode { get; set; } //used to control/maintain the image names(Temporarily) on the database

        [DisplayName("Product Price")]
        [Required(ErrorMessage ="Fill in the Product Price.")]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        //[Required(ErrorMessage ="Please provide the Product description")]
        //Add a Word count range (10-800)
        public string ProductDescription { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage ="Please select a catefory.")]
        public int CategoryID { get; set; } //Foreign key  Property

        public Category Category {  get; set; }//Navigation property 
    }
}
