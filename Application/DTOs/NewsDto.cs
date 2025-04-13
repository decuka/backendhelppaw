// Application/DTOs/NewsDto.cs
namespace HelPaw.Application.DTOs;

public class NewsDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid AuthorId { get; set; }
    public string? AuthorName { get; set; }
}
