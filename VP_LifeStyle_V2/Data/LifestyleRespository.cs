
using Microsoft.EntityFrameworkCore;
using VP_Lifestyle.Models;



namespace VP_Lifestyle.Data
{
    public class LifestyleRepository : ILifestyleRepository
    {
        //Creaet a DbContext variable ensure it's read-only
        private readonly LifestyleDbContext _lifestyleDbContext;

        //Implement the constructor always
        public LifestyleRepository(LifestyleDbContext lifestyleDbContext)
        {
            _lifestyleDbContext = lifestyleDbContext;
        }

        public void AddCategory(Category category)
        {
            _lifestyleDbContext.Categories.Add(category);
           
        }

        public void AddProduct(Product product)
        {
            _lifestyleDbContext.Products.Add(product);
        }

        public void DeleteCategory(Category category)
        {
            _lifestyleDbContext.Categories.Remove(category);
        }

        public void DeleteProduct(Product product)
        {
            _lifestyleDbContext.Products.Remove(product);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _lifestyleDbContext.Categories;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _lifestyleDbContext.Products;
        }

        public IEnumerable<Product> GetallProductsInCategory(string categoryName)
        {
            var cat = _lifestyleDbContext.Categories.FirstOrDefault(c => c.CategoryName.ToLower() == c.CategoryName.ToLower());
            return _lifestyleDbContext.Products.Where(pro => pro.CategoryID == pro.CategoryID);
           
        }

        public IEnumerable<Product> GetAllProductsWithCategoryDetails()
        {
            return _lifestyleDbContext.Products.Include(m => m.Category);
        }

        public Category GetCategoryById(int categoryId)
        {
            return _lifestyleDbContext.Categories
                   .FirstOrDefault(cat => cat.CategoryID == categoryId);
        }

        public Product GetProductById(int productId)
        {
            return _lifestyleDbContext.Products
                   .FirstOrDefault(pro => pro.ProductID == productId);
        }

        public void saveChanges()
        {
            _lifestyleDbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _lifestyleDbContext.Update(category);
        }

        public void UpdateProduct(Product product)
        {
            _lifestyleDbContext.Update(product);
        }
    }
}
