using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class WordController : Controller
    {
        [HttpGet]
        [Route("api/dictionaries/{id}/words", Name = "GetWords")]
        public async Task<PageView<WordView>> Get(int id, int pageNumber = 1, int pageSize = 10)
        {
            return await ApiClient.Get<PageView<WordView>>($"api/dictionaries/{id}/words?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        [HttpGet("api/words/{id}", Name = "GetWordById")]
        public async Task<WordView> Get(int id)
        {
            return await ApiClient.Get<WordView>($"api/words/{id}");
        }

        [HttpGet]
        [Route("api/dictionaries/{id}/Search", Name = "SearchDictionary")]
        public async Task<PageView<WordView>> SearchDictionary(int id, string query, int pageNumber = 1, int pageSize = 10)
        {
            return await ApiClient.Get<PageView<WordView>>($"api/dictionaries/{id}/Search?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        [HttpGet]
        [Route("api/dictionaries/{id}/words/startWith/{startingWith}", Name = "GetWordsListStartWith")]
        public async Task<PageView<WordView>> StartsWith(int id, string startingWith, int pageNumber = 1, int pageSize = 10)
        {
            return await ApiClient.Get<PageView<WordView>>($"api/dictionaries/{id}/words/startWith/{startingWith}?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        [Route("api/words/search/{title}", Name = "WordSearch")]
        [HttpGet]
        public async Task<PageView<WordView>> Search(string title, int pageNumber = 1, int pageSize = 10)
        {
            return await ApiClient.Get<PageView<WordView>>($"api/words/search/{title}?pageNumber={pageNumber}&pageSize={pageSize}");
        }
    }
}