using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PROJECT_NAME.Api.Configurations.Extensions;
using PROJECT_NAME.Api.Middleware;
using PROJECT_NAME.Application.Interfaces;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;
using PROJECT_NAME.Infrastructure.CosmosDb;
using PROJECT_NAME.Infrastructure.Dapr;
using PROJECT_NAME.Infrastructure.Models;
using System.Text.Json.Serialization;

JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
{
    ContractResolver = new DefaultContractResolver()
    {
      NamingStrategy  = new CamelCaseNamingStrategy()
    },
    DateTimeZoneHandling = DateTimeZoneHandling.Utc
};

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName.ToLowerInvariant()}.json", optional: true, reloadOnChange: true);

// Add services to the container.
services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});

services.AddLogging(config =>
{
    config.AddDebug();
    config.AddConsole();    
});
services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAutoMapper(
    typeof(Result<>),
    typeof(UserEntity),
    typeof(TodoItemEntity));
services.AddMediatR(
    typeof(Result<>));
services.AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining(typeof(Result<>));
    });

services.Configure<CosmosConfiguration>(configuration.GetSection(CosmosConfiguration.Key));
services.Configure<UserUpdateConfiguration>(configuration.GetSection(DaprEventTopicConfiguration.Key).GetSection(UserUpdateConfiguration.Key));

services.AddSingleton<ITodoRepository, TodoRepository>();
services.AddSingleton<IEventRepository, EventRepository>();
services.AddSingleton<IMaterializedViewRepository<UserEntity>, MaterializedViewRepository<UserEntity>>();
services.AddSingleton<IDaprService, DaprService>();

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaggerDocumentation(provider);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
