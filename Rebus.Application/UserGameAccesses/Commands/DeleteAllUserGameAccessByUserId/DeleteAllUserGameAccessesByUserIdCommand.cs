using MediatR;

namespace Rebus.Application.UserGameAccesses.Commands.DeleteAllUserGameAccessByUserId;

public class DeleteAllUserGameAccessesByUserIdCommand(string userId) : IRequest
{
    public string UserId { get; } = userId;
}
