
using Rebus.Domain.Entities;

namespace Rebus.Domain.Repositories;

public interface IUsersRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<int> Create(User entity);
}
