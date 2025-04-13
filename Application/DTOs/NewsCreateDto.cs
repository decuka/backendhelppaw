// Application/DTOs/NewsCreateDto.cs
namespace HelPaw.Application.DTOs;

public class NewsCreateDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string? ImageUrl { get; set; }
}
