using HelPaw.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HelPaw.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Volunteer")]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteAnimalService _service;

    public FavoriteController(IFavoriteAnimalService service)
    {
        _service = service;
    }

    [HttpPost("{animalId}")]
    public async Task<IActionResult> AddFavorite(Guid animalId)
    {
        var userId = GetUserId();
        await _service.AddToFavoritesAsync(userId, animalId);
        return Ok();
    }

    [HttpDelete("{animalId}")]
    public async Task<IActionResult> RemoveFavorite(Guid animalId)
    {
        var userId = GetUserId();
        await _service.RemoveFromFavoritesAsync(userId, animalId);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetFavorites()
    {
        var userId = GetUserId();
        var result = await _service.GetFavoritesAsync(userId);
        return Ok(result);
    }

    private Guid GetUserId()
    {
        var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return Guid.Parse(id ?? throw new Exception("User ID not found"));
    }
}
