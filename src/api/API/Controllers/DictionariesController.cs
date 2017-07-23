using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class DictionariesController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public DictionariesController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet("/api/dictionaries", Name = "GetDictionaries")]
        public async Task<DictionariesView> Get()
        {
            return await _queryProcessor.ExecuteAsync(new GetDictionariesQuery());
        }

        [HttpGet("/api/dictionaries/{id}", Name = "GetDictionaryById")]
        public async Task<DictionaryView> Get(int id)
        {
            return await _queryProcessor.ExecuteAsync(new GetDictionaryByIdQuery { Id = id });
        }
    }
}