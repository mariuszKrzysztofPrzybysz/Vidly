using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers
                .Include(c => c.MembershipType)
                .Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);

            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri($"{Request.RequestUri}/{customerDto.Id}"), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult PutCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDatabase = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDatabase == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDatabase);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customerDto/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDatabase = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDatabase == null)
                return NotFound();

            _context.Customers.Remove(customerInDatabase);

            _context.SaveChanges();

            return Ok();
        }
    }
}