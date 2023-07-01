using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lingoSimApi.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly QuoteRepository _quoteRepository;
        public QuoteController(QuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetAllQuotes()
        {
            var quotes = await _quoteRepository.GetQuotes();
            return Ok(quotes);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var quotes = _quoteRepository.GetQuotes();
            return Ok(quotes);
        }
    }
}
