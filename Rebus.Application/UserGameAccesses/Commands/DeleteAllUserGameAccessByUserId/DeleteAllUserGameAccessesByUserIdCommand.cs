using MediatR;

namespace Rebus.Application.UserGameAccesses.Commands.DeleteAllUserGameAccessByUserId;

public class DeleteAllUserGameAccessesByUserIdCommand(int userId) : IRequest
{
    public int UserId { get; } = userId;
}
