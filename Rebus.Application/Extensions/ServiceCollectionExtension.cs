using Microsoft.Extensions.DependencyInjection;
using Rebus.Application.Users;

namespace Rebus.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, UsersService>();

    }
}
