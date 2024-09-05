using Dotnetstore.Intranet.WebAPI.Extensions;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi();

var app = builder.Build();

app.UseFastEndpoints();

app.Run(); 