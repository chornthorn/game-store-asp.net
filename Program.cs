using GameStore.Api.Core;
using GameStore.Api.DI;
using GameStore.Api.Games;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AutoDependencyInjection();
builder.Services.ManualDependency();

builder.Services.AddAuthentication().AddBearerToken();
builder.Services.AddAuthorization();

var app = builder.Build();

// Initialize database
await app.InitializeDatabase();

app.MapGet("/", () => "Hello World!");
app.MapGamesController();

app.Run();
