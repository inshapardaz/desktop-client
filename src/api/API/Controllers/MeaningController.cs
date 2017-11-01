using System.Collections.Generic;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Adapters;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;
using MeaningView = Inshapardaz.Desktop.Api.Model.MeaningView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class MeaningController : Controller
    {
        private readonly IAmACommandProcessor _commandProcessor;

        public MeaningController(IAmACommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        [HttpGet("api/dictionaries/{id}/words/{wordId}/meanings", Name = "GetWordMeaningByWordId")]
        [Produces(typeof(IEnumerable<MeaningView>))]
        public async Task<IActionResult> GetMeaningForWord(int id, int wordId)
        {
            var request = new GetMeaningForWordRequest
            {
                DictionaryId = id,
                WordId = wordId
            };

            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }
        
        [HttpGet("api/dictionaries/{id}/words/{wordId}/meanings/contexts/{context}", Name = "GetWordMeaningByContext")]
        [Produces(typeof(IEnumerable<MeaningView>))]
        public async Task<IActionResult> GetMeaningForContext(int id, int wordId, string context)
        {
            var request = new GetMeaningForContextRequest
            {
                DictionaryId = id,
                WordId = wordId,
                Context = context
            };

            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }

        [HttpGet("api/dictionaries/{id}/meanings/{meaningId}", Name = "GetMeaningById")]
        [Produces(typeof(MeaningView))]
        public async Task<IActionResult> Get(int id, int meaningId)
        {
            var request = new GetMeaningByIdRequest
            {
                DictionaryId = id,
                MeaningId = meaningId
            };

            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }
    }
}