using DocBot.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocBot.Controllers;


[Route("api/[controller]")]
public class ChatsController : ControllerBase {
    private readonly IMediator mediator;

    public ChatsController(IMediator mediator) {
        this.mediator = mediator;
    }
    
    [HttpPost("/chat")]
    public async Task<ActionResult<ChatResponse>> Post() {
        var result = await mediator.Send(new CreateChatCommand());
        return Ok(result.Guid);
    }
    
    [HttpGet("{chatId}")]
    public async Task<ActionResult<ChatResponse>> Get(string chatId) {
        var result = await mediator.Send(new GetChatQuery(chatId));
        return Ok(result);
    }
}