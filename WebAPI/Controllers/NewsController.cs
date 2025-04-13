using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HelPaw.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    [HttpPost]
    [Authorize(Roles = "Shelter")]
    public async Task<IActionResult> CreateNews([FromBody] NewsCreateDto dto)
    {
        var userId = GetUserId();
        await _newsService.CreateNewsAsync(userId, dto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var news = await _newsService.GetAllNewsAsync();
        return Ok(news);
    }

    private Guid GetUserId()
    {
        var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.Parse(idClaim ?? throw new Exception("User ID not found"));
    }
}
