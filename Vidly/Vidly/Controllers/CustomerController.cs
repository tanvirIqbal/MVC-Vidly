using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [Route("Customers")]
        public ActionResult ShowCustomers()
        {
            MovieViewModel oMovieViewModel = new MovieViewModel();
            oMovieViewModel.Customers = GetCustomer();
            return View("Customers",oMovieViewModel);
        }

        public ActionResult Details(int Id)
        {
            Customer oCustomer = GetCustomer().FirstOrDefault(x => x.Id == Id);
            return View(oCustomer);
        }

        public List<Customer> GetCustomer()
        {
            List<Customer> oCustomers = new List<Customer>()
            {
                new Customer(){ Id = 1, Name = "Al Masum Fahim"},
                new Customer(){ Id = 2, Name = "Zubayer Jamil"}
            };

            return oCustomers;
        }
    }
}