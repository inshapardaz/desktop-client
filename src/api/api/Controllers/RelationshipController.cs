using System.Collections.Generic;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Adapters;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;
using RelationshipView = Inshapardaz.Desktop.Api.Model.RelationshipView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class RelationshipController : Controller
    {
        private readonly IAmACommandProcessor _commandProcessor;

        public RelationshipController(IAmACommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        [HttpGet("/api/dictionaries/{id}/words/{wordId}/relationships", Name = "GetWordRelationsById")]
        [Produces(typeof(IEnumerable<RelationshipView>))]
        public async Task<IActionResult> GetRelationshipByWord(int id, int wordId)
        {
            var request = new GetRelationshipsByWordRequest
            {
                DictionaryId = id,
                WordId = wordId
            };
            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }

        [HttpGet("/api/dictionaries/{id}/relationships/{relationshipId}", Name = "GetRelationById")]
        [Produces(typeof(RelationshipView))]
        public async Task<IActionResult> Get(int id, int relationshipId)
        {
            var request = new GetRelationshipByIdRequest
            {
                DictionaryId = id,
                RelationshipId = relationshipId
            };
            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }
    }
}