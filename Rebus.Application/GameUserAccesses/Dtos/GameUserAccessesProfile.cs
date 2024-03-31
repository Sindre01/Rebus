using AutoMapper;
using Rebus.Domain.Entities;

namespace Rebus.Application.GameUserAccesses.Dtos
{
    public class GameUserAccessesProfile : Profile
    {
        public GameUserAccessesProfile()
        {
            CreateMap<GameUserAccess, GameUserAccessDto>();
                //.ForMember(d => d.User, opt =>
                  //  opt.MapFrom(src => src.User))
                //.ForMember(d => d.GameAccessCode, opt =>
                   // opt.MapFrom(src => src.GameAccessCode));
        }

    }
}
