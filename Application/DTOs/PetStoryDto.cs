namespace HelPaw.Application.DTOs;

public class PetStoryDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string Content { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
    public string? UserName { get; set; } // для відображення
}
        