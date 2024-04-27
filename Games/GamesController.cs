using GameStore.Api.Dtos;

namespace GameStore.Api.Games;

public static class GamesController
{
    public static RouteGroupBuilder MapGamesController(this IEndpointRouteBuilder routes)
    {

        var gameGroup = routes.MapGroup("/games");

        gameGroup.MapGet("/", async (GamesService gamesService) =>
        {
            var games = await gamesService.GetGames();
            return Results.Ok(games);
        });

        gameGroup.MapGet("/{id}", async (GamesService gamesService, int id) =>
        {
            var game = await gamesService.GetGame(id);
            if (game == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(game);
        });

        gameGroup.MapPost("/", async (GamesService gamesService, CreateGameDto createGameDto) =>
        {
            var game = await gamesService.CreateGame(createGameDto);
            return Results.Created($"/games/{game.Id}", game);
        })
         .WithParameterValidation()
         .RequireAuthorization();

        gameGroup.MapPut("/{id}", async (GamesService gamesService, int id, UpdateGameDto updateGameDto) =>
        {
            var game = await gamesService.UpdateGame(id, updateGameDto);
            if (game == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(game);
        })
        .WithParameterValidation()
        .RequireAuthorization();

        gameGroup.MapDelete("/{id}", async (GamesService gamesService, int id) =>
        {
            var deleted = await gamesService.DeleteGame(id);
            if (!deleted)
            {
                return Results.NotFound();
            }
            return Results.NoContent();
        })
        .RequireAuthorization();

        return gameGroup;
    }
}
