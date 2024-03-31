
using Rebus.Domain.Entities;

namespace Rebus.Domain.Repositories;

public interface IGameUserAccessesRepository
{
    Task<IEnumerable<GameUserAccess>> GetAllAsync();
    Task<GameUserAccess?> GetByIdAsync(int id);
}
