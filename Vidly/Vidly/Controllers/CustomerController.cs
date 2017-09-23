﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        #region Context
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _context.Dispose();
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            return View();
        }
        [Route("Customers")]
        public ActionResult ShowCustomers()
        {
            MovieViewModel oMovieViewModel = new MovieViewModel();
            oMovieViewModel.Customers = _context.Customers.Include(x => x.MembershipType).ToList();
            return View("Customers", oMovieViewModel);
        }

        public ActionResult Details(int Id)
        {
            Customer oCustomer = _context.Customers.Include(x => x.MembershipType).FirstOrDefault(x => x.Id == Id);
            return View(oCustomer);
        }
        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipType
            };
            return View(viewModel);
        }
        [HttpPost] // To Make sure it only use Http Post not Http Get
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("ShowCustomers","Customer");
        }
        #endregion

        #region Methods
        public List<Customer> GetCustomer()
        {
            List<Customer> oCustomers = new List<Customer>()
            {
                new Customer(){ Id = 1, Name = "Al Masum Fahim"},
                new Customer(){ Id = 2, Name = "Zubayer Jamil"}
            };

            return oCustomers;
        } 
        #endregion
    }
}