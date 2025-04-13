namespace HelPaw.Application.DTOs;

public class SendMessageDto
{
    public Guid ReceiverId { get; set; }
    public string Content { get; set; } = null!;
    public string? ImageUrl { get; set; }
}
