using Dotnetstore.Intranet.WebAPI.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi(builder.Configuration);

var app = builder.Build();

app
    .UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints()
    .UseSwaggerGen()
    .UseExceptionHandler();

await app.RunAsync();

namespace Dotnetstore.Intranet.WebAPI
{
    public partial class Program;
}