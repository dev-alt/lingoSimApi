using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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

        [HttpGet("random")]
        public async Task<ActionResult<Quote>> GetRandomQuote()
        {
            var count = await _quoteRepository.GetQuotesCount();
            var random = new Random();
            var randomIndex = random.Next((int)count);
            var quote = await _quoteRepository.GetQuoteByIndex(randomIndex);
            if (quote == null)
                return NotFound();

            return Ok(quote);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetAllQuotes()
        {
            var quotes = await _quoteRepository.GetAllQuotes();
            return Ok(quotes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuoteById(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
                return BadRequest("Invalid ID");

            var quote = await _quoteRepository.GetQuoteById(objectId);
            if (quote == null)
                return NotFound();

            return Ok(quote);
        }
    }
}
