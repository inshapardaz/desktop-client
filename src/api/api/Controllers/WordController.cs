using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Adapters;
using Inshapardaz.Desktop.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;
using WordView = Inshapardaz.Desktop.Api.Model.WordView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class WordController : Controller
    {
        private readonly IAmACommandProcessor _commandProcessor;

        public WordController(IAmACommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }
        [HttpGet("api/dictionaries/{id}/words", Name = "GetWords")]
        [Produces(typeof(PageView<WordView>))]
        public async Task<IActionResult> GetWords(int id, int pageNumber = 1, int pageSize = 10)
        {
            var request = new GetWordsByDictionaryRequest
            {
                DictionaryId = id,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }
        
        [HttpGet("api/dictionaries/{id}/words/{wordId}", Name = "GetWordById")]
        [Produces(typeof(WordView))]
        public async Task<IActionResult> GetWordById(int id, int wordId)
        {
            var request = new GetWordByIdRequest
            {
                DictionaryId = id,
                WordId = wordId
            };

            await _commandProcessor.SendAsync(request);

            return Ok(request.Result);
        }

        [HttpGet("api/dictionaries/{id}/Search", Name = "SearchDictionary")]
        [Produces(typeof(PageView<WordView>))]
        public async Task<IActionResult> SearchDictionary(int id, string query, int pageNumber = 1, int pageSize = 10)
        {
            var request = new SearchWordRequest
            {
                DictionaryId = id,
                Query = query,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            await _commandProcessor.SendAsync(request);

            return Ok(request.Result);
        }

        [HttpGet("api/dictionaries/{id}/words/startWith/{startingWith}", Name = "GetWordsListStartWith")]
        [Produces(typeof(PageView<WordView>))]
        public async Task<IActionResult> StartsWith(int id, string startingWith, int pageNumber = 1, int pageSize = 10)
        {
            var request = new GetWordsStartingWithRequest
            {
                DictionaryId = id,
                StartingWith = startingWith,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            await _commandProcessor.SendAsync(request);

            return Ok(request.Result);
        }
    }
}