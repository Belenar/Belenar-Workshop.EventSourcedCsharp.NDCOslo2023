using BeerSender.Domain.Box.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BeerSender.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        // Polymorphic deserialization 
        // Should not use TypeNameHandling=auto due to security vulnerabilities
        [HttpPost]
        public IActionResult Post([FromBody] Command command)
        {
            //TODO
            return Accepted();
        }
    }
}
