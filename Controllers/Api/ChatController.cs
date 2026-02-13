using Microsoft.AspNetCore.Mvc;
using projetNet.DTOs;
using projetNet.Services.ServiceContracts;
using System.Security.Claims;

namespace projetNet.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatAssistantService _chatService;

    public ChatController(IChatAssistantService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] ChatRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
            return BadRequest(new { message = "Message cannot be empty." });

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        try
        {
            var reply = await _chatService.GetResponseAsync(request.Message, userId);
            return Ok(new ChatResponseDto { Reply = reply });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "AI assistant is temporarily unavailable. Please try again later." });
        }
    }
}
