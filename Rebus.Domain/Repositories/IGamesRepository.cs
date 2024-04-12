using Rebus.Domain.Entities;

namespace Rebus.Domain.Repositories;

public interface IGamesRepository
{
    Task<IEnumerable<Game>> GetAllAsync();
    Task<Game?> GetByIdAsync(int id);
    Task<int> Create(Game entity);
    Task Delete(Game entity);
    Task SaveChanges();
}
