namespace HelPaw.Application.DTOs;

public class PetStoryCreateDto
{
    public string? Title { get; set; }
    public string Content { get; set; } = null!;
    public string? ImageUrl { get; set; }
}
