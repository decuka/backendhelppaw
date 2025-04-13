// Application/DTOs/MessageDto.cs
namespace HelPaw.Application.DTOs;

public class MessageDto
{
    public Guid Id { get; set; }
    public Guid ChatId { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Content { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public DateTime SentAt { get; set; }
    public bool IsRead { get; set; }
}
