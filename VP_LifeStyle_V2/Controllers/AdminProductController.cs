using VP_Lifestyle.Data;
using VP_Lifestyle.Models;
using VP_Lifestyle.Models.ProductMenuViewModel;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace VP_Lifestyle.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminProductController : Controller
    {
        //Create a readonly variables for interface type
        private readonly ILifestyleRepository _LifestyleRepository;
        private readonly IEnumerable<Category> _categories; //Will store the category data
        
        public AdminProductController(ILifestyleRepository lifestyleRepository)
        {
            _LifestyleRepository = lifestyleRepository;
            _categories = _LifestyleRepository.GetAllCategories()
                          .OrderBy(cat => cat.CategoryName);
        }
        public IActionResult Product(string id ="all")
        {
            //create an IEnumerable to store the product
            IEnumerable<Product> products;

            if (id == "all")
            {
                products = _LifestyleRepository.GetAllProduct()
                           .OrderBy(pro => pro.ProductName).ToList();
            }
            else
            {
               products = _LifestyleRepository.GetAllProductsWithCategoryDetails()
                           .Where(pro => pro.Category.CategoryName.ToLower() == id.ToLower())
                           .OrderBy(pro => pro.ProductName).ToList();
            }
            //instatiate a ProductListViewModel 

            var model = new ProductMenuViewModel
            {
                Categories = _categories,
                Products = products,
                SelectedCategory = id
            };

            //Create a viewbag to temporary store categories 
            //and the selecteed category id/name
            ViewBag.Categories = _categories;
            ViewBag.SelectedCategoryName = id;

            return View(model);
        }

        //Add
        [HttpGet] //Retrieves data from the server e.g fetching the webpage.
        public IActionResult Add()
        {
            //Add default category object to avoid validation issue
           // Category category = _LifestyleRepository.GetCategoryById(1);
            //Viewbag to indicate the type of action being performed
            ViewBag.Categories = _LifestyleRepository.GetAllCategories();
            ViewBag.Action = "Add";
            // bind product to AddUpdate view
            return View("AddUpdate", new Product());

        }

        //Update
        [HttpGet]
        
        public IActionResult Update(int id)
        {
           ViewBag.Action = "Update";
           ViewBag.Categories = _categories;
           var Product = _LifestyleRepository.GetProductById(id);
           return View("AddUpdate",Product);
        }

        //ManageProduct
        [HttpPost]//Sends data to the server e.g Submitting a form
        public ActionResult ManageProduct(Product product)
        {
            if (ModelState.IsValid) /*validate the data sent to a controller action from a form or other client-side submission*/
            {
                //Adding a new product, it's id is equal to Zero
                if (product.ProductID == 0)
                {
                    _LifestyleRepository.AddProduct(product);
                    //Store temporary lived messages or text
                    TempData["Message"] = $"'{product.ProductName}'  haves been successfully added.";
                } //Update the product since it has it's own id
                else
                {
                    _LifestyleRepository.UpdateProduct(product);
                    TempData["Message"] = $"'{product.ProductName}' has been successfully Updated.";
                }
                _LifestyleRepository.saveChanges();
                return RedirectToAction("Product");
            }
            else
            {
                //Ensures the application doesn't break during run-time
                ViewBag.Action = "Save";
                ViewBag.Categories = _categories;
                return View("AddUpdate",product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _LifestyleRepository.GetProductById(id);
              
            // return View("Delete",product);-still works but stating the view is not neccessary
            ViewBag.Action = "Delete";
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            //Add hidden properties to the form for every
            ////Use ModelState isValid, to validate if the actual product is passed or not
            //if (ModelState.IsValid)
            //{

            //}
            //else
            //{
            //    return RedirectToAction("Product");
            //}

        _LifestyleRepository.DeleteProduct(product);
         TempData["Message"] = $"'{product.ProductName}' has been successfully deleted";
         _LifestyleRepository.saveChanges();
         return RedirectToAction("Product");

        }
    }
}
