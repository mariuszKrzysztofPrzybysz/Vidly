using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Profiles
{
    public class MembershipTypeProfile : Profile
    {
        public MembershipTypeProfile()
        {
            CreateMap<MembershipType, MembershipTypeDto>();

            CreateMap<MembershipTypeDto, MembershipType>();
        }
    }
}