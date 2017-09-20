using System;
using System.Collections.Generic;
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
        public async Task<IEnumerable<MeaningView>> GetMeaningForWord(int id)
        {
            var result =  await _queryProcessor.ExecuteAsync(new GetMeaningsByWordIdQuery { Id = id });
            return result.Select(x => _meaningRenderer.Render(x));
        }

        [HttpGet("api/details/{id}/meanings", Name = "GetWordMeaningByWordDetailId")]
        public async Task<IEnumerable<MeaningView>> GetMeaningForWordDetail(int id)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetMeaningsByWordDetailIdQuery { DetailId = id });
            return result.Select(x => _meaningRenderer.Render(x));
        }

        [HttpGet("api/meanings/{id}", Name = "GetMeaningById")]
        public async Task<MeaningView> Get(int id)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetMeaningByIdQuery { Id = id });
            return _meaningRenderer.Render(result);
        }

        [HttpGet("api/words/{id}/meanings/contexts/{context}", Name = "GetWordMeaningByContext")]
        public async Task<IEnumerable<MeaningView>> GetMeaningForContext(int id, string context)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetMeaningByContextQuery { Id = id, Context = context });
            return result.Select(x => _meaningRenderer.Render(x));
        }
    }
}