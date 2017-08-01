﻿using System;
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
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No MovieIds have been given");

            var customer = _context.Customers
                .SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid");

            var movies = _context.Movies
                .Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

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