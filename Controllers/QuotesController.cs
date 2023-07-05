using Microsoft.AspNetCore.Mvc;

namespace lingoSimApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;

        public QuotesController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var quotes = _cosmosDbService.GetQuotes();
            return Ok(quotes);
        }
    }
}