using MediatR;

namespace Rebus.Application.UserGameAccesses.Commands.DeleteUserGameAccess;

public class DeleteUserGameAccessCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}
