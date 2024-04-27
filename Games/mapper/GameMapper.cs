using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mappers;

public static class GameMapper
{
      public static GameDto ToDto(this Game game)
      {
            return new GameDto
            {
                  Id = game.Id,
                  Name = game.Name,
                  Price = game.Price,
                  ReleaseDate = game.ReleaseDate,
                  Genre = game.Genre,
                  ImageUrl = game.ImageUrl,
            };
      }

      public static Game ToEntity(this GameDto gameDto)
      {
            return new Game
            {
                  Id = gameDto.Id,
                  Name = gameDto.Name,
                  Price = gameDto.Price,
                  ReleaseDate = gameDto.ReleaseDate,
                  Genre = gameDto.Genre,
                  ImageUrl = gameDto.ImageUrl,
            };
      }

      public static CreateGameDto ToCreateDto(this GameDto gameDto)
      {
            return new CreateGameDto
            {
                  Name = gameDto.Name,
                  Price = gameDto.Price,
                  ReleaseDate = gameDto.ReleaseDate,
                  Genre = gameDto.Genre,
                  ImageUrl = gameDto.ImageUrl,
            };
      }

      public static UpdateGameDto ToUpdateDto(this GameDto gameDto)
      {
            return new UpdateGameDto
            {
                  Name = gameDto.Name,
                  Price = gameDto.Price,
                  ReleaseDate = gameDto.ReleaseDate,
                  Genre = gameDto.Genre,
                  ImageUrl = gameDto.ImageUrl,
            };
      }
}
