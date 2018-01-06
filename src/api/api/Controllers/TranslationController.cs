using System.Collections.Generic;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Adapters;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class TranslationController : Controller
    {
        private readonly IAmACommandProcessor _commandProcessor;

        public TranslationController(IAmACommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        [HttpGet("api/dictionaries/{id}/words/{wordId}/translations", Name = "GetWordTranslationsById")]
        [Produces(typeof(IEnumerable<TranslationView>))]
        public async Task<IActionResult> GetTranslationsForWord(int id, int wordId)
        {
            var request = new GetTranslationsForWordRequest
            {
                DictionaryId = id,
                WordId = wordId
            };
            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }
        

        [HttpGet("api/dictionaries/{id}/words/{wordId}/translations/languages/{language}", Name = "GetWordTranslationsByWordIdAndLanguage")]
        [Produces(typeof(IEnumerable<TranslationView>))]
        public async Task<IActionResult> GetTranslationForWord(int id, int wordId, LanguageType language)
        {
            var request = new GetTranslationsForLanguageRequest
            {
                DictionaryId = id,
                WordId = wordId,
                Language = language
            };
            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }
        
        [HttpGet("api/dictionaries/{id}/translations/{translationId}", Name = "GetTranslationById")]
        [Produces(typeof(TranslationView))]
        public async Task<IActionResult> Get(int id, int translationId)
        {
            var request = new GetTranslationByIdRequest
            {
                DictionaryId = id,
                TranslationId = translationId
            };
            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }
    }
}