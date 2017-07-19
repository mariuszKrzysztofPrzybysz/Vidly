using System;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>();

            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}