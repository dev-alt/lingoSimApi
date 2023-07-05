using lingoSimApi;
using Microsoft.AspNetCore.Mvc;


namespace lingoSimApi.Controllers
{
    public class PhraseController : Controller
    {
        private readonly PhraseRepository _phraseRepository;

        public PhraseController(PhraseRepository phraseRepository)
        {
            _phraseRepository = phraseRepository;
        }

        public ActionResult GetPhraseOfTheDay(string language)
        {
            var phrase = _phraseRepository.GetRandomPhrase(language);

            if (phrase == null)
            {
                return NotFound();
            }

            return View(phrase);
        }
    }
}