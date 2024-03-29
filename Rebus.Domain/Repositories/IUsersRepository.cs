
using Rebus.Domain.Entities;

namespace Rebus.Domain.Repositories;

public interface IUsersRepository
{
    Task<IEnumerable<User>> GetAllAsync();
}
