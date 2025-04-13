// Application/Services/NewsService.cs
using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using HelPaw.Domain.Entities;
using HelPaw.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelPaw.Application.Services;

public class NewsService : INewsService
{
    private readonly AppDbContext _context;

    public NewsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateNewsAsync(Guid authorId, NewsCreateDto dto)
    {
        var news = new News
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Content = dto.Content,
            ImageUrl = dto.ImageUrl,
            AuthorId = authorId
        };

        _context.News.Add(news);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<NewsDto>> GetAllNewsAsync()
    {
        return await _context.News
            .Include(n => n.Author)
            .OrderByDescending(n => n.CreatedAt)
            .Select(n => new NewsDto
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                ImageUrl = n.ImageUrl,
                CreatedAt = n.CreatedAt,
                AuthorId = n.AuthorId,
                AuthorName = n.Author.FullName
            })
            .ToListAsync();
    }
}
