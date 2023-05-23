using BeerSender.Domain;
using BeerSender.Domain.Box.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BeerSender.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandController : ControllerBase
{
    private readonly Command_router _command_router;
    public CommandController(Command_router command_router) 
    {
        _command_router = command_router;
    }

/*
{"$type":"Select_box_size",
"command": {
"Aggregate_id":"73b004bc-e859-4b2a-a299-d3221b760334", 
"Number_of_bottles":24
}
}
 */
    [HttpPost]
    public IActionResult Post([FromBody] ICommand command)
    {
        _command_router.Handle_command(command);
        return Accepted();
    }
    
}