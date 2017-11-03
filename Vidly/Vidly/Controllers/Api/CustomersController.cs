using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<CustomerDTO> GetCustomer()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        // GET /api/customers/1
        public CustomerDTO GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer, CustomerDTO>(customer);
        }

        // POST /api/customers
        [HttpPost]
        public CustomerDTO CreateCustomer(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;
            return customerDTO;
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(customerDTO, customerInDb);

            _context.SaveChanges();
        }

        // DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
