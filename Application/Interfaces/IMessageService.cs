using HelPaw.Application.DTOs;

namespace HelPaw.Application.Interfaces;
public interface IMessageService
{
    Task SendMessageAsync(Guid senderId, Guid receiverId, string content, string? imageUrl = null);
    Task<IEnumerable<MessageDto>> GetMessagesAsync(Guid chatId);
    Task<IEnumerable<ChatDto>> GetChatsAsync(Guid userId);
}
