
using Rebus.Domain.Entities;

namespace Rebus.Domain.Repositories;

public interface IUserGameAccessesRepository
{
    Task<IEnumerable<UserGameAccess>> GetAllAsync();
    Task<IEnumerable<UserGameAccess>> GetByUserIdAsync(int id);
    Task<UserGameAccess?> GetByIdAsync(int id);
    Task<int> Create(UserGameAccess entity);
    Task Delete(UserGameAccess entity);
    Task SaveChanges();

}
