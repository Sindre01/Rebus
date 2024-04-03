using MediatR;

namespace Rebus.Application.Users.Commands.DeleteUser;

public class DeleteUserCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}
