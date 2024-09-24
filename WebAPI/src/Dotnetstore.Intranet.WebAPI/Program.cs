using Dotnetstore.Intranet.WebAPI.Extensions;

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

public partial class Program;