using HealthApp.Application;
using HealthApp.Infrastructure;
using HealthApp.Web.Api;
using HealthApp.Web.Api.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

var mongoConnectionString = builder.Configuration.GetConnectionString("MongoConnection")!;

builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(mongoConnectionString);

var app = builder.Build();

app.MapEndpoints();

app.MapHealthChecks("/health");

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();
}

app.UseRequestContextLogging();
app.UseSerilogRequestLogging();

await app.RunAsync();