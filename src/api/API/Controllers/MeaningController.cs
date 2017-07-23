using System.Collections.Generic;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class MeaningController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public MeaningController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        [Route("api/words/{id}/meanings", Name = "GetWordMeaningById")]
        public async Task<IEnumerable<MeaningView>> GetMeaningForWord(int id)
        {
            return await _queryProcessor.ExecuteAsync(new GetMeaningsByWordIdQuery { Id = id });
        }

        [HttpGet("api/meanings/{id}", Name = "GetMeaningById")]
        public async Task<MeaningView> Get(int id)
        {
            return await _queryProcessor.ExecuteAsync(new GetMeaningByIdQuery { Id = id });
        }

        [HttpGet]
        [Route("api/words/{id}/meanings/contexts/{context}", Name = "GetWordMeaningByContext")]
        public async Task<IEnumerable<MeaningView>> GetMeaningForContext(int id, string context)
        {
            return await _queryProcessor.ExecuteAsync(new GetMeaningByContextQuery { Id = id, Context = context });
        }
    }
}