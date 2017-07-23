using System.Collections.Generic;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class TranslationController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public TranslationController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        [Route("api/words/{id}/translations", Name = "GetWordTranslationsById")]
        public async Task<IEnumerable<TranslationView>> GetTranslationForWord(int id)
        {
            return await _queryProcessor.ExecuteAsync(new GetTranslationsByWordIdQuery { Id = id });
        }

        [HttpGet]
        [Route("api/words/{id}/translations/languages/{language}")]
        public async Task<IEnumerable<TranslationView>> GetTranslationForWord(int id, LanguageType language)
        {
            return await _queryProcessor.ExecuteAsync(new GetTranslationsByLanguageQuery { Id = id, Language = language });
        }

        [HttpGet("api/translations/{id}", Name = "GetTranslationById")]
        public async Task<TranslationView> Get(int id)
        {
            return await _queryProcessor.ExecuteAsync(new GetTranslationByIdQuery { Id = id });
        }
    }
}