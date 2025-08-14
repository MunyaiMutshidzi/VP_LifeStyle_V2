using VP_Lifestyle.Models;
namespace VP_Lifestyle.Data
{
    public interface ILifestyleRepository
    {
        IEnumerable<Product> GetallProductsInCategory(string categoryName);
        IEnumerable<Product> GetAllProductsWithCategoryDetails();
        IEnumerable<Product> GetAllProduct();
        Product GetProductById(int productId);
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);

        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);

        void saveChanges();
    }
}
