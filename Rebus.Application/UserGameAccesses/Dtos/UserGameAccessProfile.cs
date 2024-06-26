﻿using AutoMapper;
using Rebus.Application.UserGameAccesses.Commands.CreateUserGameAccess;
using Rebus.Domain.Entities;

namespace Rebus.Application.UserGameAccesses.Dtos
{
    public class UserGameAccessProfile : Profile
    {
        public UserGameAccessProfile()
        {
            CreateMap<CreateUserGameAccessCommand, UserGameAccess>();
            CreateMap<UserGameAccess, UserGameAccessDto>();
            //.ForMember(d => d.User, opt =>
            //  opt.MapFrom(src => src.User))
            //.ForMember(d => d.GameAccessCode, opt =>
            // opt.MapFrom(src => src.GameAccessCode));
        }

    }
}
