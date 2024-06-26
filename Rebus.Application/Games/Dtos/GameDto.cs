﻿using Rebus.Application.GameCreators.Dtos;
using Rebus.Application.UserGameAccesses.Dtos;

namespace Rebus.Application.Games.Dtos;
public class GameDto
{
/*    public enum Statuses
    {
        Editing,
        Unactive,
        Active
    }*/
    public int GameId { get; set; }
    public string GameName { get; set; } = string.Empty;
    //public Statuses Status { get; set; }
    public string AccessCode { get; set; } = string.Empty;
    public int? CurrentPlayers { get; set; }
    public int? MaxPlayers { get; set; }
/*    public List<GameCreatorDto> GameCreators { get; set; } = [];
    public List<UserGameAccessDto> UserGameAccesses { get; set; } = [];*/
    public string? GameDescription { get; set; }
    public DateTime? DateCreated { get; set; }
    //public List<UserGameHistoryDto> UserGameHistories { get; set; } = [];

}


