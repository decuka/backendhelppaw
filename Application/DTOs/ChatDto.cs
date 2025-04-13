namespace HelPaw.Application.DTOs;

public class ChatDto
{
    public Guid ChatId { get; set; }
    public Guid InterlocutorId { get; set; }
    public string InterlocutorName { get; set; } = null!;
    public string? InterlocutorAvatar { get; set; }
    public string LastMessage { get; set; } = null!;
    public DateTime LastMessageTime { get; set; }
    public bool IsRead { get; set; }
}
