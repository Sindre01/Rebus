using AutoMapper;
using Rebus.Domain.Entities;

namespace Rebus.Application.GameCreators.Dtos
{
    public class GameCreatorsProfile : Profile
    {
        public GameCreatorsProfile()
        {
            CreateMap<GameCreator, GameCreatorDto>();
        }

    }
}
