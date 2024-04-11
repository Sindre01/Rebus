
using Rebus.Domain.Entities;

namespace Rebus.Domain.Repositories;

public interface IUserGameAccessesRepository
{
    Task<IEnumerable<UserGameAccess>> GetAllAsync();
    Task<UserGameAccess?> GetByIdAsync(int id);
}
