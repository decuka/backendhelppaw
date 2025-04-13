// Application/Services/AnimalService.cs
using HelPaw.Application.DTOs;
using HelPaw.Application.DTOs.Animal;
using HelPaw.Application.Interfaces;
using HelPaw.Domain.Entities;
using HelPaw.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelPaw.Application.Services;

public class AnimalService : IAnimalService
{
    private readonly AppDbContext _context;

    public AnimalService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AnimalDto> CreateAnimalAsync(AnimalCreateDto dto, Guid shelterId)
    {
        var animal = new Animal
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Type = dto.Type,
            Age = dto.Age,
            Gender = dto.Gender,
            Description = dto.Description,
            IsVaccinated = dto.IsVaccinated,
            IsSterilized = dto.IsSterilized,
            Condition = dto.Condition,
            Size = dto.Size,
            ImageUrl = dto.ImageUrl,
            ShelterId = shelterId,
            IsActive = true
        };

        _context.Animals.Add(animal);
        await _context.SaveChangesAsync();

        await _context.Entry(animal).Reference(a => a.Shelter).LoadAsync();


        return MapToDto(animal);
    }

    public async Task<IEnumerable<AnimalDto>> GetAnimalsAsync(AnimalFilterDto filter)
    {
        var query = _context.Animals
            .Where(a => a.IsActive)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Type))
            query = query.Where(a => a.Type == filter.Type);

        if (!string.IsNullOrEmpty(filter.Gender))
            query = query.Where(a => a.Gender == filter.Gender);

        if (filter.MinAge.HasValue)
            query = query.Where(a => a.Age >= filter.MinAge.Value);

        if (filter.MaxAge.HasValue)
            query = query.Where(a => a.Age <= filter.MaxAge.Value);

        if (!string.IsNullOrEmpty(filter.City))
            query = query.Where(a => a.Shelter.City == filter.City);

        if (!string.IsNullOrEmpty(filter.Size))
            query = query.Where(a => a.Size == filter.Size);

        if (filter.IsVaccinated.HasValue)
            query = query.Where(a => a.IsVaccinated == filter.IsVaccinated.Value);

        if (filter.IsSterilized.HasValue)
            query = query.Where(a => a.IsSterilized == filter.IsSterilized.Value);

        if (!string.IsNullOrEmpty(filter.Condition))
            query = query.Where(a => a.Condition == filter.Condition);

        var animals = await query
            .Include(a => a.Shelter)
            .ToListAsync();

        return animals.Select(MapToDto);
    }

    public async Task<AnimalDto?> GetAnimalByIdAsync(Guid id)
    {
        var animal = await _context.Animals
            .Include(a => a.Shelter)
            .FirstOrDefaultAsync(a => a.Id == id && a.IsActive);

        return animal != null ? MapToDto(animal) : null;
    }

    public async Task UpdateAnimalAsync(Guid id, AnimalUpdateDto dto, Guid shelterId)
    {
        var animal = await _context.Animals.FindAsync(id);
        if (animal == null) throw new Exception("Animal not found");

        // check ownership
        if (animal.ShelterId != shelterId)
            throw new UnauthorizedAccessException("You are not allowed to update this animal.");

        animal.Name = dto.Name ?? animal.Name;
        animal.Description = dto.Description ?? animal.Description;
        animal.Age = dto.Age ?? animal.Age;
        animal.Gender = dto.Gender ?? animal.Gender;
        animal.Type = dto.Type ?? animal.Type;
        animal.ImageUrl = dto.ImageUrl ?? animal.ImageUrl;
        animal.Size = dto.Size ?? animal.Size;
        animal.IsVaccinated = dto.IsVaccinated ?? animal.IsVaccinated;
        animal.IsSterilized = dto.IsSterilized ?? animal.IsSterilized;
        animal.Condition = dto.Condition ?? animal.Condition;
        animal.IsActive = dto.IsActive ?? animal.IsActive;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAnimalAsync(Guid id, Guid shelterId)
    {
        var animal = await _context.Animals.FindAsync(id);
        if (animal == null) throw new Exception("Animal not found");

        // check ownership
        if (animal.ShelterId != shelterId)
            throw new UnauthorizedAccessException("You are not allowed to delete this animal.");

        animal.IsActive = false;
        await _context.SaveChangesAsync();
    }
    private static AnimalDto MapToDto(Animal a)
    {
        return new AnimalDto
        {
            Id = a.Id,
            Name = a.Name,
            Type = a.Type,
            Age = a.Age,
            Gender = a.Gender,
            Description = a.Description,
            ImageUrl = a.ImageUrl,
            Size = a.Size,
            IsVaccinated = a.IsVaccinated,
            IsSterilized = a.IsSterilized,
            Condition = a.Condition,
            ShelterId = a.ShelterId,
            ShelterName = a.Shelter.FullName,
            City = a.Shelter.City
        };
    }

}
