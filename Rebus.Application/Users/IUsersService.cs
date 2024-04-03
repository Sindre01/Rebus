using Rebus.Application.Users.Dtos;

namespace Rebus.Application.Users
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto?> GetById(int id);
        Task<int> Create(CreateUserDto dto);  
    }
}