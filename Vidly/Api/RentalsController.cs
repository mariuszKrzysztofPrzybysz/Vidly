using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Api
{
    public class RentalsController : ApiController
    {
        private readonly ApplicationDbContext _context=new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult NewRental(RentalDto newRental)
        {
            var customer = _context.Customers
                .SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Invalid customer Id");

            var movies = _context.Movies
                .Where(m => newRental.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}