using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using HelPaw.Domain.Entities;
using HelPaw.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelPaw.Application.Services;

public class ShelterRequestService : IShelterRequestService
{
    private readonly AppDbContext _context;

    public ShelterRequestService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ShelterRequestDto> CreateRequestAsync(ShelterRequestCreateDto dto, Guid volunteerId)
    {
        var request = new ShelterRequest
        {
            Id = Guid.NewGuid(),
            AnimalType = dto.AnimalType,
            Name = dto.Name,
            Age = dto.Age,
            Gender = dto.Gender,
            Size = dto.Size,
            IsVaccinated = dto.IsVaccinated,
            IsSterilized = dto.IsSterilized,
            Condition = dto.Condition,
            Description = dto.Description,
            Location = dto.Location,
            ImageUrl = dto.ImageUrl,
            VolunteerId = volunteerId,
            ShelterId = dto.ShelterId,
            Status = "New"
        };

        _context.ShelterRequests.Add(request);
        await _context.SaveChangesAsync();

        return MapToDto(request);
    }

    public async Task<IEnumerable<ShelterRequestDto>> GetRequestsForShelterAsync(Guid shelterId)
    {
        var requests = await _context.ShelterRequests
            .Where(r => r.ShelterId == shelterId)
            .ToListAsync();

        return requests.Select(MapToDto);
    }

    public async Task UpdateRequestStatusAsync(Guid requestId, string newStatus)
    {
        var request = await _context.ShelterRequests.FindAsync(requestId)
            ?? throw new Exception("Request not found");

        request.Status = newStatus;
        await _context.SaveChangesAsync();
    }

    private static ShelterRequestDto MapToDto(ShelterRequest r)
    {
        return new ShelterRequestDto
        {
            Id = r.Id,
            AnimalType = r.AnimalType,
            Name = r.Name,
            Age = r.Age,
            Gender = r.Gender,
            Size = r.Size,
            IsVaccinated = r.IsVaccinated,
            IsSterilized = r.IsSterilized,
            Condition = r.Condition,
            Description = r.Description,
            Location = r.Location,
            ImageUrl = r.ImageUrl,
            Status = r.Status,
            VolunteerId = r.VolunteerId,
            ShelterId = r.ShelterId
        };
    }
}
