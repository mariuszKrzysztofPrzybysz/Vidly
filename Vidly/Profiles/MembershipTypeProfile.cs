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

            CreateMap<MembershipTypeDto, MembershipType>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}