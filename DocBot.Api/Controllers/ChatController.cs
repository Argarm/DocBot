using Microsoft.AspNetCore.Mvc;

namespace DocBot.Controllers;


public class ChatController : ControllerBase {
    [HttpPost("chat")]
    public async Task<ActionResult<string>> post() {
        return Ok("Hello World!");
    }
}