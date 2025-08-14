using VP_Lifestyle.Data;
using VP_Lifestyle.Models;
using VP_Lifestyle.Models.ProductMenuViewModel;
using Microsoft.AspNetCore.Mvc;

namespace VP_Lifestyle.Controllers
{
    public class ProductController : Controller
    {
        //Declare a readonly ILifeStyleRespository variable
        private readonly ILifestyleRepository _lifeStyleRespository;

       //Create a construct of the Controller (MenuController)\
        public ProductController(ILifestyleRepository lifeStyleRespository)
        {
            _lifeStyleRespository = lifeStyleRespository;
        }

        public IActionResult Menu(string id = "Breakfast")
        {
            var products = _lifeStyleRespository.GetallProductsInCategory(id)
                            .OrderBy(pro => pro.Price).ToList();


            //Implement viewbag - used to store temporary data generated during run time
            ViewBag.Categories = _lifeStyleRespository.GetAllCategories()
                                 .OrderBy(cat => cat.CategoryName);
            ViewBag.SelectedCategoryName = id;
            var model = new ProductMenuViewModel
            {
                Categories = _lifeStyleRespository.GetAllCategories(),
                Products = products,
                SelectedCategory = id
            };

            return View(model);

        }
        //Details

        public IActionResult Detail(int id)
        {
            Models.Product product = _lifeStyleRespository.GetProductById(id);
            if(product != null)
            {
                //Stores the product code (used as file name)
                ViewBag.ImageFile =product.ProductCode;
                return View(product);
            }
            else
                return RedirectToAction("Menu");
        }
    }
}
