using Rebus.Domain.Entities;

namespace Rebus.Application.Users
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}