using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public class GameDto
{
      public int Id { get; set; }
      [Required]
      [StringLength(50)]
      public required string Name { get; set; }

      [Required]
      [StringLength(20)]
      public required string Genre { get; set; }

      [Range(1, 100)]
      public decimal Price { get; set; }
      public DateTime ReleaseDate { get; set; }

      [Url]
      [StringLength(200)]
      public required string ImageUrl { get; set; }
}

public class CreateGameDto : GameDto
{
}

public class UpdateGameDto : CreateGameDto
{
}
