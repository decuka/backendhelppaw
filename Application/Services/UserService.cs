using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using HelPaw.Domain.Entities;
using HelPaw.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserProfileDto> GetProfileAsync(Guid userId)
    {
        var user = await _context.Users.FindAsync(userId)
            ?? throw new Exception("User not found");

        return new UserProfileDto
        {
            Email = user.Email,
            FullName = user.FullName,
            City = user.City,
            AvatarUrl = user.AvatarUrl,
            Description = user.Description,
            Role = user.Role
        };
    }

    public async Task UpdateProfileAsync(Guid userId, UserProfileUpdateDto dto)
    {
        var user = await _context.Users.FindAsync(userId)
            ?? throw new Exception("User not found");

        if (dto.ShelterCategory != null && user.Role != "Shelter")
            throw new Exception("Only shelters can set a category.");

        user.ShelterCategory = dto.ShelterCategory ?? user.ShelterCategory;

        user.FullName = dto.FullName ?? user.FullName;
        user.City = dto.City ?? user.City;
        user.AvatarUrl = dto.AvatarUrl ?? user.AvatarUrl;
        user.Description = dto.Description ?? user.Description;

        await _context.SaveChangesAsync();
    }
}
