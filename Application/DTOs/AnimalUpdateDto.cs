// Application/DTOs/AnimalUpdateDto.cs
namespace HelPaw.Application.DTOs;

public class AnimalUpdateDto
{
    public string? Type { get; set; }         // Optional update
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? Size { get; set; } // Small, Medium, Large
    public string? Description { get; set; }
    public string? Gender { get; set; }
    public string? ImageUrl { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsVaccinated { get; set; }
    public bool? IsSterilized { get; set; }
    public string? Condition { get; set; }
}
