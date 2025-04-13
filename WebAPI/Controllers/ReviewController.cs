using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HelPaw.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _service;

    public ReviewController(IReviewService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Volunteer")]
    public async Task<IActionResult> AddReview([FromBody] ReviewCreateDto dto)
    {
        var volunteerId = GetUserId();
        await _service.AddReviewAsync(volunteerId, dto);
        return Ok();
    }

    [HttpGet("{shelterId}")]
    public async Task<IActionResult> GetReviews(Guid shelterId)
    {
        var reviews = await _service.GetReviewsForShelterAsync(shelterId);
        return Ok(reviews);
    }

    [HttpGet("{shelterId}/average")]
    public async Task<IActionResult> GetAverageRating(Guid shelterId)
    {
        var avg = await _service.GetAverageRatingAsync(shelterId);
        return Ok(avg);
    }

    private Guid GetUserId()
    {
        var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.Parse(idClaim ?? throw new Exception("User ID not found"));
    }
}
