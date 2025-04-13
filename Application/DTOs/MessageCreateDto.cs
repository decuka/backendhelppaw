// Application/DTOs/MessageCreateDto.cs
namespace HelPaw.Application.DTOs;

public class MessageCreateDto
{
    public Guid ReceiverId { get; set; }
    public required string Content { get; set; }
    public string? ImageUrl { get; set; }

}
