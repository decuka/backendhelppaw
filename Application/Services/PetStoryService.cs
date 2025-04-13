using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using HelPaw.Domain.Entities;
using HelPaw.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


public class PetStoryService : IPetStoryService
{
    private readonly AppDbContext _context;

    public PetStoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PetStoryDto>> GetAllAsync()
    {
        return await _context.PetStories
            .Include(x => x.User)
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new PetStoryDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                ImageUrl = x.ImageUrl,
                CreatedAt = x.CreatedAt,
                UserId = x.UserId,
                UserName = x.User.FullName
            })
            .ToListAsync();
    }

    public async Task<PetStoryDto?> GetByIdAsync(Guid id)
    {
        var story = await _context.PetStories
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);

        return story == null ? null : new PetStoryDto
        {
            Id = story.Id,
            Title = story.Title,
            Content = story.Content,
            ImageUrl = story.ImageUrl,
            CreatedAt = story.CreatedAt,
            UserId = story.UserId,
            UserName = story.User.FullName
        };
    }

    public async Task<PetStoryDto> CreateAsync(PetStoryCreateDto dto, Guid userId)
    {
        var story = new PetStory
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Title = dto.Title,
            Content = dto.Content,
            ImageUrl = dto.ImageUrl
        };

        _context.PetStories.Add(story);
        await _context.SaveChangesAsync();

        return new PetStoryDto
        {
            Id = story.Id,
            Title = story.Title,
            Content = story.Content,
            ImageUrl = story.ImageUrl,
            CreatedAt = story.CreatedAt,
            UserId = story.UserId
        };
    }

    public async Task DeleteAsync(Guid id, Guid userId)
    {
        var story = await _context.PetStories.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        if (story == null) throw new Exception("Not found or no permission");

        _context.PetStories.Remove(story);
        await _context.SaveChangesAsync();
    }
}
