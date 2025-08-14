using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VP_Lifestyle.Models
{
    public class Category
    {
        //Adding validations
        public int CategoryID { get; set; }

        [DisplayName("Category name")] //This attribute specifies a friendly or user-friendly name for the property
                                       //when displayed in UI components or validation messages.
        [Required(ErrorMessage ="Please fill Category name.")]
        public string  CategoryName { get; set; }

       //[Required(ErrorMessage ="Please fill in the description")]
        //add the required WordCountRange (10-100)
        public string CategoryDescription { get; set; }
        //Navigation Property
        public List<Product> Product {  get; set; }
    }
}
