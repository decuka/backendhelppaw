// Application/DTOs/FavoriteAnimalDto.cs
namespace HelPaw.Application.DTOs;

public class FavoriteAnimalDto
{
    public Guid AnimalId { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public string? ImageUrl { get; set; }
}
