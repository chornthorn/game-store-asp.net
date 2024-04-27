using GameStore.Api.Core.attributes;
using GameStore.Api.Dtos;

namespace GameStore.Api.Games;


[Injectable]
public class GamesService
{
    private readonly GamesRepository _gamesRepository;
    public GamesService(GamesRepository gamesRepository)
    {

        _gamesRepository = gamesRepository;
    }

    public async Task<List<GameDto>> GetGames()
    {
        return await _gamesRepository.FindAll();
    }

    public async Task<GameDto?> GetGame(int id)
    {
        return await _gamesRepository.FindOne(id);
    }

    public async Task<GameDto> CreateGame(CreateGameDto createGameDto)
    {
        return await _gamesRepository.Create(createGameDto);
    }

    public async Task<GameDto?> UpdateGame(int id, UpdateGameDto updateGameDto)
    {
        return await _gamesRepository.Update(id, updateGameDto);
    }

    public async Task<bool> DeleteGame(int id)
    {
        return await _gamesRepository.Delete(id);
    }
};
