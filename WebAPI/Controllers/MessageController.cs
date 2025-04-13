using HelPaw.Application.DTOs;
using HelPaw.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HelPaw.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MessageController : ControllerBase
{
    private readonly IMessageService _service;

    public MessageController(IMessageService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageDto dto)
    {
        var senderId = GetUserId();
        await _service.SendMessageAsync(senderId, dto.ReceiverId, dto.Content, dto.ImageUrl);
        return Ok();
    }

    [HttpGet("chat/{chatId}")]
    public async Task<IActionResult> GetMessages(Guid chatId)
    {
        var messages = await _service.GetMessagesAsync(chatId);
        return Ok(messages);
    }

    [HttpGet("chats")]
    public async Task<IActionResult> GetChats()
    {
        var userId = GetUserId();
        var chats = await _service.GetChatsAsync(userId);
        return Ok(chats);
    }

    private Guid GetUserId()
    {
        var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return Guid.Parse(id ?? throw new Exception("User ID not found"));
    }
}
