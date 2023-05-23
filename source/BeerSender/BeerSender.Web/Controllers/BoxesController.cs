using BeerSender.Web.ReadStore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeerSender.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxesController : ControllerBase
    {
        private readonly Read_context _db_context;

        public BoxesController(Read_context db_context)
        {
            _db_context = db_context;
        }

        [HttpGet]
        public async Task<IEnumerable<Box_status>> Get_all()
        {
            var boxes = await _db_context.Boxes
                .Include(box => box.Bottles)
                .ToListAsync();

            return boxes;
        } 
    }
}
