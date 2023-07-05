using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace lingoSimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly AuthorRepository _authorRepository;

        public AuthorController(AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
                return BadRequest("Invalid ID");

            var quote = await _authorRepository.GetAuthorById(objectId);

            return Ok(quote);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuthor(Author quote)
        {
            await _authorRepository.CreateAuthor(quote);

            // Return only the _id field in the response
            var response = new { quote.Id };
            return CreatedAtAction(nameof(GetAuthorById), new { id = quote.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(string id, Author updatedAuthor)
        {
            if (!ObjectId.TryParse(id, out var objectId))
                return BadRequest("Invalid ID");

            var existingAuthor = await _authorRepository.GetAuthorById(objectId);
            if (existingAuthor == null)
                return NotFound();

            updatedAuthor.Id = existingAuthor.Id;
            await _authorRepository.UpdateAuthor(objectId, updatedAuthor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
                return BadRequest("Invalid ID");

            var existingAuthor = await _authorRepository.GetAuthorById(objectId);
            if (existingAuthor == null)
                return NotFound();

            await _authorRepository.DeleteAuthor(objectId);

            return NoContent();
        }
    }
}
