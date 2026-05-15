using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project5Day.WebApi.Context;

namespace Project5Day.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchEventController : ControllerBase
    {
        private readonly ApiContext _context;

        public MatchEventController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchEvents(int id)
        {
            var values = await _context.MatchEvents
                .Where(x => x.MatchId == id)
                .OrderBy(x => x.Minute)
                .ToListAsync();

            return Ok(values);
        }
    }
}