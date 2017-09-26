using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;
using WordDetailView = Inshapardaz.Desktop.Api.Model.WordDetailView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class WordDetailController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<WordDetailModel, WordDetailView> _wordDetailRenderer;

        public WordDetailController(IQueryProcessor queryProcessor, IRenderResponseFromObject<WordDetailModel, WordDetailView> wordDetailRenderer)
        {
            _queryProcessor = queryProcessor;
            _wordDetailRenderer = wordDetailRenderer;
        }

        [HttpGet("/api/words/{id}/details", Name = "GetWordDetailsById")]
        public async Task<IActionResult> GetForWord(int id)
        {
            var result =  await _queryProcessor.ExecuteAsync(new GetDetailsByWordIdQuery { Id = id });
            return Ok(result.Select(x => _wordDetailRenderer.Render(x)));
        }

        [HttpGet("/api/details/{id}", Name = "GetDetailsById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetDetailByIdQuery { Id = id });
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_wordDetailRenderer.Render(result));
        }
    }
}