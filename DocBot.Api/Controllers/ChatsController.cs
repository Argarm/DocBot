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
    
    [HttpPost("{chatName}")]
    public async Task<ActionResult> Post(string chatName) {
        var result = await mediator.Send(new CreateChatCommand{chatName = chatName});
        return Ok();
    }
}