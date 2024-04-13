using AutoMapper;
using Rebus.Application.Games.Commands.CreateGame;
using Rebus.Application.Users.Commands.CreateUser;
using Rebus.Domain.Entities;

namespace Rebus.Application.Games.Dtos
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<CreateGameCommand, Game>();
        }

    }
}
