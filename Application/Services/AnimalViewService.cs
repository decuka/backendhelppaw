// Application/Services/AnimalViewService.cs
using HelPaw.Application.Interfaces;
using HelPaw.Infrastructure.Data;
using HelPaw.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelPaw.Application.Services;

public class AnimalViewService : IAnimalViewService
{
    private readonly AppDbContext _context;

    public AnimalViewService(AppDbContext context)
    {
        _context = context;
    }

    public async Task RecordViewAsync(Guid animalId, Guid? userId)
    {
        var view = new AnimalView
        {
            Id = Guid.NewGuid(),
            AnimalId = animalId,
            UserId = userId,
            ViewedAt = DateTime.UtcNow
        };

        _context.AnimalViews.Add(view);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetTotalViewsAsync(Guid animalId)
    {
        return await _context.AnimalViews
            .CountAsync(v => v.AnimalId == animalId);
    }

    public async Task<int> GetUniqueUserViewsAsync(Guid animalId)
    {
        return await _context.AnimalViews
            .Where(v => v.AnimalId == animalId && v.UserId != null)
            .Select(v => v.UserId)
            .Distinct()
            .CountAsync();
    }
}
