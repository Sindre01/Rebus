
using Microsoft.OpenApi.Models;
using Rebus.API.Middlewares;
using Rebus.Application.Extensions;
using Rebus.Domain.Entities;
using Rebus.Infrastructure.Extensions;
using Rebus.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;

var builder  = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
        {
            Type= SecuritySchemeType.Http,
            Scheme= "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
                },
                []
            }
        });
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRebusSeeder>();

await seeder.Seed();
// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/identity").MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
