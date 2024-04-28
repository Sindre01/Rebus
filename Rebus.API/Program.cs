using Rebus.API.Extensions;
using Rebus.API.Middlewares;
using Rebus.Application.Extensions;
using Rebus.Domain.Entities;
using Rebus.Infrastructure.Extensions;
using Rebus.Infrastructure.Seeders;
using Serilog;

var builder  = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddPresentation();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

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
