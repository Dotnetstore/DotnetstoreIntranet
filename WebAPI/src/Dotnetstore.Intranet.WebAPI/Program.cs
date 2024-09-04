using Dotnetstore.Intranet.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebAPI();

var app = builder.Build();

app.Run();