using System.Linq;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;
using MeaningView = Inshapardaz.Desktop.Api.Model.MeaningView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class MeaningController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<MeaningModel, MeaningView> _meaningRenderer;
        public MeaningController(IQueryProcessor queryProcessor, IRenderResponseFromObject<MeaningModel, MeaningView> meaningRenderer)
        {
            _queryProcessor = queryProcessor;
            _meaningRenderer = meaningRenderer;
        }

        [HttpGet("api/words/{id}/meanings", Name = "GetWordMeaningByWordId")]
        public async Task<IActionResult> GetMeaningForWord(int id)
        {
            var result =  await _queryProcessor.ExecuteAsync(new GetMeaningsByWordIdQuery { WordId = id });
            return Ok(result.Select(x => _meaningRenderer.Render(x)));
        }
        
        [HttpGet("api/words/{id}/meanings/contexts/{context}", Name = "GetWordMeaningByContext")]
        public async Task<IActionResult> GetMeaningForContext(int id, string context)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetMeaningByContextQuery { WordId = id, Context = context });
            return Ok(result.Select(x => _meaningRenderer.Render(x)));
        }

        [HttpGet("api/meanings/{id}", Name = "GetMeaningById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetMeaningByIdQuery { MeaningId = id });
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_meaningRenderer.Render(result));
        }
    }
}