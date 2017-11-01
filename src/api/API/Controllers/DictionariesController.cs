using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Adapters;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Inshapardaz.Desktop.Domain.Command;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;
using Paramore.Darker;
using DictionariesView = Inshapardaz.Desktop.Api.Model.DictionariesView;
using DictionaryView = Inshapardaz.Desktop.Api.Model.DictionaryView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class DictionariesController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IAmACommandProcessor _commandProcessor;
        private readonly IRenderResponseFromObject<DictionariesModel, DictionariesView> _dictionariesRenderer;
        private readonly IRenderResponseFromObject<DictionaryModel, DictionaryView> _dictionaryRenderer;

        public DictionariesController(IQueryProcessor queryProcessor,
                                      IAmACommandProcessor commandProcessor,
                                      IRenderResponseFromObject<DictionariesModel, DictionariesView> dictionariesRenderer,
                                      IRenderResponseFromObject<DictionaryModel, DictionaryView> dictionaryRenderer)
        {
            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
            _dictionariesRenderer = dictionariesRenderer;
            _dictionaryRenderer = dictionaryRenderer;
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
            var downloadDictionaryCommand = new DownloadDictionaryCommand
            {
                DictionaryId = id
            };
            await _commandProcessor.SendAsync(downloadDictionaryCommand);

            await _commandProcessor.SendAsync(new AddLocalDictionaryCommand
            {
                Dictionary = downloadDictionaryCommand.Result
            });
            return Ok();
        }
    }
}