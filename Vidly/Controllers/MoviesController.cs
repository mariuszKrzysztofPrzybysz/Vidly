﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 1, Name = "Pokłosie"},
                new Movie {Id = 2, Name = "Shrek"}
            };
        }

        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        //// GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie
        //    {
        //        Name = "Shrek!"
        //    };

        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1"},
        //        new Customer {Name = "Customer 2"}
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content($"id={id}");
        //}

        //public ActionResult Index(int? pageIndex,string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content($"pageIndex={pageIndex.Value}&sortBy={sortBy}");
        //}

        //[Route(@"movies/release/{year}/{month:regex(\d{4}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content($"{year}/{month}");
        //}
    }
}