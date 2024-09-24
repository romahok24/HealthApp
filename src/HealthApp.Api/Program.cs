using HealthApp.Application;
using HealthApp.Infrastructure;
using HealthApp.Web.Api;
using HealthApp.Web.Api.Extensions;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddSwaggerGen();

var mongoConnectionString = builder.Configuration.GetConnectionString("Mongo")!;

builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(mongoConnectionString);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();
}

app.UseRequestContextLogging();
app.UseSerilogRequestLogging();
app.UseExceptionHandler();

await app.RunAsync();