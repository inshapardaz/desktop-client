using System;
using System.Linq;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;
using TranslationView = Inshapardaz.Desktop.Api.Model.TranslationView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class TranslationController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<TranslationModel, TranslationView> _translationRenderer;

        public TranslationController(IQueryProcessor queryProcessor, IRenderResponseFromObject<TranslationModel, TranslationView> translationRenderer)
        {
            _queryProcessor = queryProcessor;
            _translationRenderer = translationRenderer;
        }

        [HttpGet("api/words/{id}/translations", Name = "GetWordTranslationsById")]
        public async Task<IActionResult> GetTranslationForWord(int id)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetTranslationsByWordIdQuery { Id = id });
            return Ok(result.Select(t => _translationRenderer.Render(t)));
        }

        [HttpGet("api/detail/{id}/translations", Name = "GetWordTranslationsByDetailId")]
        public async Task<IActionResult> GetTranslationForWordDetail(int id)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetTranslationsByWordDetailIdQuery { DetailId = id });
            return Ok(result.Select(t => _translationRenderer.Render(t)));
        }

        [HttpGet("api/words/{id}/translations/languages/{language}", Name = "GetWordTranslationsByWordIdAndLanguage")]
        public async Task<IActionResult> GetTranslationForWord(int id, LanguageType language)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetTranslationsByLanguageQuery { Id = id, Language = (Common.Models.LanguageType)language });
            return Ok(result.Select(t => _translationRenderer.Render(t)));
        }

        [HttpGet("api/detail/{id}/translations/languages/{language}", Name = "GetWordTranslationsByDetailIdAndLanguage")]
        public Task<IActionResult> GetTranslationForWordDetail(int id, LanguageType language)
        {
            throw new NotImplementedException();
        }

        [HttpGet("api/translations/{id}", Name = "GetTranslationById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetTranslationByIdQuery { Id = id });

            if (result == null)
            {
                return NotFound();
            }

            return Ok(_translationRenderer.Render(result));
        }
    }
}