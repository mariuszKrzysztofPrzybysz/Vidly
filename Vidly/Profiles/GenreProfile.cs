using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();

            CreateMap<GenreDto, Genre>();
        }
    }
}