using AutoMapper;
using Rebus.Application.UserGameHistories.Dtos;
using Rebus.Domain.Entities;

namespace Rebus.Application.UserGamesHistory.Dtos
{
    public class UserGamesHistoryProfile : Profile
    {
        public UserGamesHistoryProfile()
        {
            CreateMap<UserGameHistory, UserGameHistoryDto>();
        }

    }
}
