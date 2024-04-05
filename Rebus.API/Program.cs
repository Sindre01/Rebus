
using Rebus.Application.Extensions;
using Rebus.Infrastructure.Extensions;
using Rebus.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;

var builder  = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseSerilog((ContextBoundObject, configuration) =>
    configuration
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
    .WriteTo.Console(outputTemplate : "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}| |{Newline}{Message:lj}{NewLine}{Exception}")
);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRebusSeeder>();

await seeder.Seed();
// Configure the HTTP request pipeline.
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
