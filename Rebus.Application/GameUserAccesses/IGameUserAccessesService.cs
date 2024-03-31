using Rebus.Application.GameUserAccesses.Dtos;
using Rebus.Application.Users.Dtos;

namespace Rebus.Application.GameUserAccesses
{
    public interface IGameUserAccessesService
    {
        Task<IEnumerable<GameUserAccessDto>> GetAllGameUserAccesses();
        Task<GameUserAccessDto?> GetById(int id);
    }
}