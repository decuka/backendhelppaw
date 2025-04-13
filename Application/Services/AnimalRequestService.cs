// Application/Services/AnimalRequestService.cs
using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using HelPaw.Domain.Entities;
using HelPaw.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelPaw.Application.Services;

public class AnimalRequestService : IAnimalRequestService
{
    private readonly AppDbContext _context;

    public AnimalRequestService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AnimalRequestDto> CreateAsync(AnimalRequestCreateDto dto, Guid volunteerId)
    {
        var request = new AnimalRequest
        {
            Id = Guid.NewGuid(),
            Type = dto.Type,
            Gender = dto.Gender,
            MinAge = dto.MinAge,
            MaxAge = dto.MaxAge,
            Size = dto.Size,
            Condition = dto.Condition,
            VolunteerId = volunteerId,
            IsActive = true
        };

        _context.AnimalRequests.Add(request);
        await _context.SaveChangesAsync();

        return MapToDto(request);
    }

    public async Task<IEnumerable<AnimalRequestDto>> GetAllAsync()
    {
        var requests = await _context.AnimalRequests
            .Where(r => r.IsActive)
            .ToListAsync();

        return requests.Select(MapToDto);
    }


    public async Task DeactivateAsync(Guid id, Guid userId)
    {
        var request = await _context.AnimalRequests.FirstOrDefaultAsync(r => r.Id == id && r.VolunteerId == userId);
        if (request == null) throw new Exception("Not found or access denied");

        request.IsActive = false;
        await _context.SaveChangesAsync();
    }

    private static AnimalRequestDto MapToDto(AnimalRequest r)
    {
        return new AnimalRequestDto
        {
            Id = r.Id,
            Type = r.Type,
            Gender = r.Gender,
            MinAge = r.MinAge,
            MaxAge = r.MaxAge,
            Size = r.Size,
            Condition = r.Condition,
            VolunteerId = r.VolunteerId
        };
    }
}
