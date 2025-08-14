using VP_Lifestyle.Models;
using VP_Lifestyle.Models.ProductMenuViewModel;
using Microsoft.AspNetCore.Mvc;
using VP_Lifestyle.Data;
using Microsoft.AspNetCore.Authorization;

namespace VP_Lifestyle.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCategory : Controller
    {

        private readonly ILifestyleRepository _repository;
        private readonly IEnumerable<Category> _categories;

        public AdminCategory(ILifestyleRepository repository)
        {
            _repository = repository;
            _categories = _repository.GetAllCategories();
        }

        public IActionResult Category()
        {                                                                           
            return View(_categories.ToList());
        }

        //Add Category
        [HttpGet]
        public IActionResult Add()
        {
            //Returns an AddUpdate view and bind it with the new category data
            ViewBag.Action = "Add";
           return View("AddUpdate",new Category());
        }

        //Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            Category category = _repository.GetCategoryById(id);
            ViewBag.Action = "Update";
            return View("AddUpdate", category);
        }

        [HttpPost]
        public IActionResult ManageCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryID == 0)
                {
                    _repository.AddCategory(category);
                    TempData["Message"] = $"'{category.CategoryName}' has successfully been added.";
                }
                else
                {
                    _repository.UpdateCategory(category);
                    TempData["Message"] = $"'{category.CategoryName}' has successfully been updated";
                }
                _repository.saveChanges();
                return RedirectToAction("Category");

            }
            else
             ViewBag.action = "Save";
            return View("AddUpdate", category);
  
        }
        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category category = _repository.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            TempData["Message"] = $"'{category.CategoryName}' has been successfully been deleted";
            _repository.DeleteCategory(category);
            _repository.saveChanges();
            return RedirectToAction("Category");
        }

    }
}
