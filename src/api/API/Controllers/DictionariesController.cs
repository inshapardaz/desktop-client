using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Adapters;
using Inshapardaz.Desktop.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class DictionariesController : Controller
    {
        private readonly IAmACommandProcessor _commandProcessor;

        public DictionariesController(IAmACommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        [HttpGet("/api/dictionaries", Name = "GetDictionaries")]
        [Produces(typeof(DictionariesView))]
        public async Task<IActionResult> Get()
        {
            var request = new GetDictionariesRequest();
            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }

        [HttpGet("/api/dictionaries/{id}", Name = "GetDictionaryById")]
        [Produces(typeof(DictionaryView))]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetDictionaryByIdRequest(id);
            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }

        [HttpGet("/api/dictionary/{id}/download", Name = "DownloadDictionary")]
        public async Task<IActionResult> DownloadDictionary(int id, [FromHeader(Name = "Accept")] string accept = "")
        {
            var request = new DownloadDictionaryRequest(id);
            await _commandProcessor.SendAsync(request);
            return Ok();
        }
    }
}