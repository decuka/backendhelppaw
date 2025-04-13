using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


[ApiController]
[Route("api/[controller]")]
public class PetStoryController : ControllerBase
{
    private readonly IPetStoryService _service;

    public PetStoryController(IPetStoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var story = await _service.GetByIdAsync(id);
        return story == null ? NotFound() : Ok(story);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(PetStoryCreateDto dto)
    {
        var userId = GetUserId();
        var created = await _service.CreateAsync(dto, userId);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = GetUserId();
        await _service.DeleteAsync(id, userId);
        return NoContent();
    }

    private Guid GetUserId()
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.Parse(id!);
    }
}
