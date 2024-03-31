using AutoMapper;
using Rebus.Domain.Entities;

namespace Rebus.Application.Users.Dtos
{
    public class UsersProfile : Profile
    {
        public UsersProfile() 
        {
            CreateMap<User, UserDto>()
                .ForMember(d => d.Latitude, opt =>
                    opt.MapFrom(src => src.Location == null ? null : src.Location.Latitude))
                .ForMember(d => d.Longitude, opt =>
                    opt.MapFrom(src => src.Location == null ? null : src.Location.Longitude))
                .ForMember(d => d.City, opt =>
                    opt.MapFrom(src => src.Location == null ? null : src.Location.City))
                .ForMember(d => d.Street, opt =>
                    opt.MapFrom(src => src.Location == null ? null : src.Location.Street))
                .ForMember(d => d.PostalCode, opt =>
                    opt.MapFrom(src => src.Location == null ? null : src.Location.PostalCode))
                .ForMember(d => d.PostalCode, opt =>
                    opt.MapFrom(src => src.Location == null ? null : src.Location.PostalCode));
        }

    }
}
