using GameStore.Api.Core.attributes;
using GameStore.Api.Core.database;
using GameStore.Api.Dtos;
using GameStore.Api.Mappers;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Games;

[Injectable]
public class GamesRepository
{
    private readonly GameStoreContext _context;
    public GamesRepository(GameStoreContext context)
    {
        _context = context;
    }

    public async Task<List<GameDto>> FindAll()
    {
        var games = await _context.Games
            .Select(g => g.ToDto())
            .ToListAsync();

        return games;
    }

    // FindOne
    public async Task<GameDto?> FindOne(int id)
    {
        var game = await _context.Games
            .Where(g => g.Id == id)
            .Select(g => g.ToDto())
            .FirstOrDefaultAsync();

        return game;
    }

    // Create
    public async Task<GameDto> Create(CreateGameDto createGameDto)
    {
        var game = createGameDto.ToEntity();
        _context.Games.Add(game);
        var response = await _context.SaveChangesAsync();
        if (response == 0)
        {
            throw new Exception("Failed to create game");
        }
        return game.ToDto();
    }

    // Update
    public async Task<GameDto?> Update(int id, UpdateGameDto updateGameDto)
    {
        var game = await _context.Games
            .Where(g => g.Id == id)
            .FirstOrDefaultAsync();

        if (game == null)
        {
            return null;
        }

        // Update the game with new field
        game.Name = updateGameDto.Name;
        game.Price = updateGameDto.Price;
        game.Genre = updateGameDto.Genre;
        game.ImageUrl = updateGameDto.ImageUrl;
        game.ReleaseDate = updateGameDto.ReleaseDate;

        var response = await _context.SaveChangesAsync();
        if (response == 0)
        {
            throw new Exception("Failed to update game");
        }
        return game.ToDto();
    }

    // Delete
    public async Task<bool> Delete(int id)
    {
        var game = await _context.Games
            .Where(g => g.Id == id)
            .FirstOrDefaultAsync();

        if (game == null)
        {
            return false;
        }

        _context.Games.Remove(game);
        var response = await _context.SaveChangesAsync();
        if (response == 0)
        {
            throw new Exception("Failed to delete game");
        }
        return true;
    }

}
