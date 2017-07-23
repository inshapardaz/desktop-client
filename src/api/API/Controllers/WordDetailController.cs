using System.Collections.Generic;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Inshapardaz.Desktop.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class WordDetailController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public WordDetailController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        [Route("/api/words/{id}/details", Name = "GetWordDetailsById")]
        public async Task<IEnumerable<WordDetailView>> GetForWord(int id)
        {
            return await _queryProcessor.ExecuteAsync(new GetDetailsByWordIdQuery { Id = id });
        }

        [HttpGet]
        [Route("/api/details/{id}", Name = "GetDetailsById")]
        public async Task<WordDetailView> Get(int id)
        {
            return await _queryProcessor.ExecuteAsync(new GetDetailByIdQuery { Id = id });
        }
    }
}