using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class WordController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public WordController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        [Route("api/dictionaries/{id}/words", Name = "GetWords")]
        public async Task<PageView<WordView>> Get(int id, int pageNumber = 1, int pageSize = 10)
        {
            return await _queryProcessor.ExecuteAsync(new GetWordsByDictionaryIdQuery { Id = id, PageNumber = pageNumber, PageSize = pageSize });
        }

        [HttpGet("api/words/{id}", Name = "GetWordById")]
        public async Task<WordView> Get(int id)
        {
            return await _queryProcessor.ExecuteAsync(new GetWordByIdQuery { Id = id });
        }

        [HttpGet]
        [Route("api/dictionaries/{id}/Search", Name = "SearchDictionary")]
        public async Task<PageView<WordView>> SearchDictionary(int id, string query, int pageNumber = 1, int pageSize = 10)
        {
            return await _queryProcessor.ExecuteAsync(new SearchWordsByDictionaryIdQuery { Id = id, Query = query, PageNumber = pageNumber, PageSize = pageSize });
        }

        [HttpGet]
        [Route("api/dictionaries/{id}/words/startWith/{startingWith}", Name = "GetWordsListStartWith")]
        public async Task<PageView<WordView>> StartsWith(int id, string startingWith, int pageNumber = 1, int pageSize = 10)
        {
            return await _queryProcessor.ExecuteAsync(new GetWordsStartingWithQuery { Id = id, StartingWith = startingWith, PageNumber = pageNumber, PageSize = pageSize });
        }

        [Route("api/words/search/{title}", Name = "WordSearch")]
        [HttpGet]
        public async Task<PageView<WordView>> Search(string title, int pageNumber = 1, int pageSize = 10)
        {
            return await _queryProcessor.ExecuteAsync(new SearchWordsByTitleQuery { Title = title, PageNumber = pageNumber, PageSize = pageSize });
        }
    }
}