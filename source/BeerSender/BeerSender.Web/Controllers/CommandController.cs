using BeerSender.Domain.Box;
using Microsoft.AspNetCore.Mvc;

namespace BeerSender.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandController
{
    private readonly Command_router _command_router;

    public CommandController(Command_router command_router)
    {
        _command_router = command_router;
    }
    [HttpPost]
    public IActionResult Post([FromBody] Command command)
    {
        _command_router.Handle_command(command);
        return new AcceptedResult();
    }
}