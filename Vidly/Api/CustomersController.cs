using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDto>(customer);
        }

        // POST /api/customers
        [HttpPost]
        public CustomerDto PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);

            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        // PUT /api/customers/1
        [HttpPut]
        public void PutCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDatabase = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDatabase == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDatabase);

            _context.SaveChanges();
        }

        // DELETE /api/customerDto/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDatabase = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDatabase == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDatabase);

            _context.SaveChanges();
        }
    }
}