using System;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Adapters;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;

namespace API.Controllers
{
    public class OfflineController : Controller
    {
        private readonly IAmACommandProcessor _commandProcessor;

        public OfflineController(IAmACommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        [HttpGet("/api/dictionaries/offline")]
        public async Task<IActionResult> GetOfflineDictionaries()
        {
            var request = new GetOfflineDictionariesRequest();
            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }
    }
}