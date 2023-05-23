using BeerSender.Domain.Box.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerSender.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] Command command)
        {
            return Accepted();
        }
    }
}
