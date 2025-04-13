// Application/DTOs/AnimalCreateDto.cs
namespace HelPaw.Application.DTOs;

public class AnimalCreateDto
{
    public required string Type { get; set; }
    public required string Name { get; set; }
    public int? Age { get; set; }
    public string? Size { get; set; } // Small, Medium, Large
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Gender { get; set; }
    public bool? IsVaccinated { get; set; }
    public bool? IsSterilized { get; set; }
    public string? Condition { get; set; }
}
