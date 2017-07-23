using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class ThesaurusController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public ThesaurusController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet("api/alternates/{word}", Name = "GetWordAlternatives")]
        public async Task<PageView<WordView>> Get(string word, int pageNumber = 1, int pageSize = 10)
        {
            return await _queryProcessor.ExecuteAsync(new GetAlternatesByWordIdQuery { Word = word, PageNumber = pageNumber, PageSize = pageSize });
        }
    }
}