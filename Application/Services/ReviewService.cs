// Application/Services/ReviewService.cs
using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using HelPaw.Domain.Entities;
using HelPaw.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelPaw.Application.Services;

public class ReviewService : IReviewService
{
    private readonly AppDbContext _context;

    public ReviewService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddReviewAsync(Guid volunteerId, ReviewCreateDto dto)
    {
        var review = new Review
        {
            Id = Guid.NewGuid(),
            ShelterId = dto.ShelterId,
            VolunteerId = volunteerId,
            Rating = dto.Rating,
            Comment = dto.Comment,
            CreatedAt = DateTime.UtcNow
        };

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ReviewDto>> GetReviewsForShelterAsync(Guid shelterId)
    {
        return await _context.Reviews
            .Where(r => r.ShelterId == shelterId)
            .Select(r => new ReviewDto
            {
                VolunteerId = r.VolunteerId,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<double> GetAverageRatingAsync(Guid shelterId)
    {
        var ratings = await _context.Reviews
            .Where(r => r.ShelterId == shelterId)
            .Select(r => r.Rating)
            .ToListAsync();

        return ratings.Any() ? ratings.Average() : 0.0;
    }
}
