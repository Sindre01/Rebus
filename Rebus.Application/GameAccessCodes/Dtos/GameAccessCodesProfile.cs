using AutoMapper;
using Rebus.Domain.Entities;

namespace Rebus.Application.GameAccessCodes.Dtos
{
    public class GameAccessCodesProfile : Profile
    {
        public GameAccessCodesProfile()
        {
            CreateMap<GameAccessCode, GameAccessCodeDto>();
        }

    }
}
