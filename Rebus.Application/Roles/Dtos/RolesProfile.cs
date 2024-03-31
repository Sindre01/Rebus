using AutoMapper;
using Rebus.Domain.Entities;

namespace Rebus.Application.Roles.Dtos
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<Role, RoleDto>();
        }

    }
}
