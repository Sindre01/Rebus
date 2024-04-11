using Rebus.Application.UserGameAccesses.Dtos;

namespace Rebus.Application.UserGameAccesses;

public interface IUserGameAccessesService
{
    Task<IEnumerable<UserGameAccessDto>> GetAllUserGameAccesses();
    Task<UserGameAccessDto?> GetById(int id);
}