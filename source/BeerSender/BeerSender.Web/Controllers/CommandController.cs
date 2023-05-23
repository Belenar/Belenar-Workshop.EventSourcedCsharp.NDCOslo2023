using BeerSender.Domain;
using BeerSender.Domain.Box.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BeerSender.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly Command_router _command_router;

        public CommandController(Command_router command_router)
        {
            _command_router = command_router;
        }

        // Polymorphic deserialization 
        // Should not use TypeNameHandling=auto due to security vulnerabilities
        [HttpPost]
        public IActionResult Post([FromBody] Command command)
        {
            _command_router.Handle_command(command);
            return Accepted();
        }
    }
}
