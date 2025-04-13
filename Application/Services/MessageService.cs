using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using HelPaw.Domain.Entities;
using HelPaw.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


public class MessageService : IMessageService
{
    private readonly AppDbContext _context;

    public MessageService(AppDbContext context)
    {
        _context = context;
    }

    public async Task SendMessageAsync(Guid senderId, Guid receiverId, string content, string? imageUrl = null)
    {
        // Перевірка чи є існуючий чат
        var chat = await _context.Chats.FirstOrDefaultAsync(c =>
            (c.User1Id == senderId && c.User2Id == receiverId) ||
            (c.User1Id == receiverId && c.User2Id == senderId));

        if (chat == null)
        {
            chat = new Chat
            {
                Id = Guid.NewGuid(),
                User1Id = senderId,
                User2Id = receiverId
            };
            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();
        }

        var message = new Message
        {
            Id = Guid.NewGuid(),
            SenderId = senderId,
            ReceiverId = receiverId,
            Content = content,
            ImageUrl = imageUrl,
            SentAt = DateTime.UtcNow,
            ChatId = chat.Id
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<MessageDto>> GetMessagesAsync(Guid chatId)
    {
        var messages = await _context.Messages
            .Where(m => m.ChatId == chatId)
            .OrderBy(m => m.SentAt)
            .ToListAsync();

        return messages.Select(m => new MessageDto
        {
            Id = m.Id,
            SenderId = m.SenderId,
            ReceiverId = m.ReceiverId,
            Content = m.Content,
            ImageUrl = m.ImageUrl,
            SentAt = m.SentAt,
            IsRead = m.IsRead
        });
    }

    public async Task<IEnumerable<ChatDto>> GetChatsAsync(Guid userId)
    {
        var chats = await _context.Chats
            .Where(c => c.User1Id == userId || c.User2Id == userId)
            .Include(c => c.User1)
            .Include(c => c.User2)
            .ToListAsync();

        return chats.Select(c => new ChatDto
        {
            ChatId = c.Id,
            InterlocutorId = c.User1Id == userId ? c.User2Id : c.User1Id,
            InterlocutorName = c.User1Id == userId ? c.User2.FullName ?? "Unknown" : c.User1.FullName ?? "Unknown"
        });
    }
}
