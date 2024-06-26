﻿

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Domain.Entities;
using Rebus.Domain.Repositories;
using Rebus.Infrastructure.Persistance;
using Rebus.Infrastructure.Repositories;
using Rebus.Infrastructure.Seeders;

namespace Rebus.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RebusDb");
        services.AddDbContext<RebusDbContext>(options => 
            options.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging());
        
        services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<RebusDbContext>();

        services.AddScoped<IRebusSeeder, RebusSeeder>();
        services.AddScoped<IGamesRepository, GamesRepository>();
        services.AddScoped<IUserGameAccessesRepository, UserGameAccessesRepository>();
    }
}
