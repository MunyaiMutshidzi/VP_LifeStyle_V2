using VP_Lifestyle.Models;
using VP_LifeStyle_V2.Models;
using VP_LifeStyle_V2.Data;
using VP_LifeStyle_V2.Data.DataAccess;
using VP_LifeStyle_V2.Models.ProductMenuViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VP_LifeStyle_V2.Controllers
{
    public class CustomerController : Controller
    {

        //Create a wrapper variable
        private readonly    IRespositoryWrapper _respositoryWrapper;

        public CustomerController(IRespositoryWrapper respositoryWrapper)
        {
            _respositoryWrapper = respositoryWrapper;
        }
        public int PageItems = 4;//Specifies the number of items(customers) per page

        [TempData]
       public string Message { get; set; } //Stores temporary message, used/updated during run-time
                                          //NB, Always ensure is of public as it data access
        [HttpGet]
        public IActionResult Index(string sortBy="CustomerLastName",string searchString="",
                                   int page=1)
            //Adding paging info/count- by default it's one (1)
        {

            IEnumerable<Customer> customers;//Declare the Collection of customers
            Expression<Func<Customer, Object>> orderBy;//
            string orderDirection;//Initialized to "asc" in the QueryOptions<T> class
            int iTotalCustomer; //The 1st count, uses Get All()[Used when there is no searchString]
                               //The 2nd count, uses GetByConditon[Used wne there is a searchString]

            //Sorting
            ViewData["NameSortParam"] = sortBy == "CustomerLastName" ? "LastName_desc" : "CustomerLastName";
            ViewData["DateSortParam"] = sortBy == "Registration" ? "Reservation_desc" : "Registration";
            ViewData["CurrentFilter"] = searchString;//contains the search term/name
            if (string.IsNullOrEmpty(sortBy)) 
            { 
                sortBy = "CustomerLastName"; 
            }
            if(sortBy.EndsWith("_desc"))
            {
                sortBy = sortBy.Substring(0,sortBy.Length-5);
                orderDirection = "desc";
            }
            else
            {
                orderDirection = "asc";

            }
            //Important
            orderBy = P => EF.Property<object>(P,sortBy);

            //Filtering/search, use FindEith Options
            if (searchString == "")
            {
                //total of the customer registered
                iTotalCustomer = _respositoryWrapper.Customer.GetAll().Count();
                //us
                customers = _respositoryWrapper.Customer.FindWithOptions(new QueryOptions<Customer>
                {
                    OrderBy = orderBy,
                    OrderByDirection = orderDirection,
                    Where = s => s.CustomerLastName.Contains(searchString) || s.CustomerFirstName.Contains(searchString),
                    PageNumber = page,
                    PageSize = PageItems

                });

            }
            else
            {
                //total of the customers that match the search term.
                 iTotalCustomer = _respositoryWrapper.Customer.FindByCondition(s => s.CustomerLastName.Contains(searchString)
                                   || s.CustomerFirstName.Contains(searchString)).Count();

                customers = _respositoryWrapper.Customer.FindWithOptions(new QueryOptions<Customer>
                {
                    OrderBy = orderBy,
                    OrderByDirection= orderDirection,
                    Where = s => s.CustomerLastName.Contains(searchString) || s.CustomerFirstName.Contains(searchString),
                    PageNumber= page,
                    PageSize = PageItems

                });


            }
            return View(new CustomerListView
            {
                Customer = customers,

                PageInfo = new PageInfoViewModel
                { 
                    CurrentPage = page,
                    ItemsPerPage = PageItems,
                    TotalItems = iTotalCustomer //Total items is retrieved from the total number of customers
                }
            });
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("CustomerManagement", new Customer());
          
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var customer = _respositoryWrapper.Customer.GetById(id);
            return View("CustomerManagement",customer);
        }

        [HttpPost]
        public IActionResult CustomerManagement(Customer customer)
        {
             //uses try & catch exception handle
            if(ModelState.IsValid)
            {
                try
                {
                    if(customer.CustomerID == 0)
                    {
                        //Initialize the data property to the day a customer register
                         customer.Registration = DateTime.Now;
                        _respositoryWrapper.Customer.Create(customer);
                     Message = $"Customer '{customer.CustomerFirstName.ToString()}' " +
                                  $"{customer.CustomerLastName.ToString()} has been added Successfully";
                    }
                    else
                    {
                        _respositoryWrapper.Customer.Update(customer);
                        ViewData["Message"] = $"Customer '{customer.CustomerFirstName.ToString()}' " +
                                  $"{customer.CustomerLastName.ToString()} has been updated Successfully";
                    }
                    _respositoryWrapper.Save();
                    return RedirectToAction("Index");
                    
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                          "Try again, and if the problem persists, " +
                          "see your system administrator.");
                }
                //Simplying the Viewbag.Action value using a conditional algorithms
            }
            ViewBag.Action = customer.CustomerID == 0 ? "Add" : "Edit";
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //Defensive language
            var customer = _respositoryWrapper.Customer.GetById(id);
            if(customer == null)
              return NotFound();// returns the not found 
            else return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            if(customer != null)
            {
                _respositoryWrapper.Customer.Delete(customer);
                _respositoryWrapper.Save();
                Message = " Customer has been deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to Delete Customer";
                 return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
           var customer = _respositoryWrapper.Customer.GetCustomerWithDetails(id);
            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
    }
}
                                                                   