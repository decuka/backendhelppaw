// Application/Interfaces/IReviewService.cs
using HelPaw.Application.DTOs;

namespace HelPaw.Application.Interfaces;

public interface IReviewService
{
    Task AddReviewAsync(Guid volunteerId, ReviewCreateDto dto);
    Task<IEnumerable<ReviewDto>> GetReviewsForShelterAsync(Guid shelterId);
    Task<double> GetAverageRatingAsync(Guid shelterId);
}
