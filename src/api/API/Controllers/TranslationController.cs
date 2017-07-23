using System.Collections.Generic;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class TranslationController : Controller
    {
        [HttpGet]
        [Route("api/words/{id}/translations", Name = "GetWordTranslationsById")]
        public async Task<IEnumerable<TranslationView>> GetTranslationForWord(int id)
        {
            return await ApiClient.Get<IEnumerable<TranslationView>>($"api/words/{id}/translations");
        }

        [HttpGet]
        [Route("api/words/{id}/translations/languages/{language}")]
        public async Task<IEnumerable<TranslationView>> GetTranslationForWord(int id, Languages language)
        {
            return await ApiClient.Get<IEnumerable<TranslationView>>($"api/words/{id}/translations/languages/{language}");
        }

        [HttpGet("api/translations/{id}", Name = "GetTranslationById")]
        public async Task<TranslationView> Get(int id)
        {
            return await ApiClient.Get<TranslationView>($"api/translations/{id}");
        }
    }
}