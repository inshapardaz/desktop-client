using System.Linq;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;
using RelationshipView = Inshapardaz.Desktop.Api.Model.RelationshipView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class RelationshipController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<RelationshipModel, RelationshipView> _relationRenderer;


        public RelationshipController(IQueryProcessor queryProcessor, IRenderResponseFromObject<RelationshipModel, RelationshipView> relationRenderer)
        {
            _queryProcessor = queryProcessor;
            _relationRenderer = relationRenderer;
        }

        [HttpGet("/api/words/{id}/relationships", Name = "GetWordRelationsById")]
        public async Task<IActionResult> GetRelationshipForWord(int id)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetRelationshipsByWordIdQuery { WordId = id });
            return Ok(result.Select(r => _relationRenderer.Render(r)));
        }

        [HttpGet("/api/relationships/{id}", Name = "GetRelationById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _queryProcessor.ExecuteAsync(new GetRelationshipByIdQuery { RelationshipId = id });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_relationRenderer.Render(result));
        }
    }
}