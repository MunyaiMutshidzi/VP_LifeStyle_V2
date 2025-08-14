namespace VP_Lifestyle.Models.ProductMenuViewModel
{
    public class ProductMenuViewModel
    {
       public IEnumerable<Category> Categories { get; set; }
       public IEnumerable<Product> Products { get; set; }
       public string SelectedCategory { get; set; }
        public string CheckActiveCategory(string category) =>
             category.ToLower() == SelectedCategory.ToLower() ? "active": " ";
    }
}
