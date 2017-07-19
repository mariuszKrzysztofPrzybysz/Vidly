﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.Select(Mapper.Map<Movie, MovieDto>);
        }

        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;


            _context.Movies.Add(movie);

            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri($"{Request.RequestUri}/{movieDto.Id}"), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDatabase = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDatabase == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDatabase);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult RemoveMovie(int id)
        {
            var movieInDatabase = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDatabase == null)
                return NotFound();

            _context.Movies.Remove(movieInDatabase);

            _context.SaveChanges();

            return Ok();
        }
    }
}