using GameStore.Api.Core;
using GameStore.Api.Core.database;
using GameStore.Api.DI;
using GameStore.Api.Games;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AutoDependencyInjection();
builder.Services.ManualDependency();

var app = builder.Build();

// Initialize database
app.InitializeDatabase();

app.MapGet("/", () => "Hello World!");
app.MapGamesController();

app.Run();
