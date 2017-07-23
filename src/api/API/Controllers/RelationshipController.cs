using System.Collections.Generic;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class RelationshipController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public RelationshipController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        [Route("/api/words/{id}/relationships", Name = "GetWordRelationsById")]
        public async Task<IEnumerable<RelationshipView>> GetRelationshipForWord(int id)
        {
            return await _queryProcessor.ExecuteAsync(new GetRelationshipsByWordIdQuery { Id = id });
        }

        [HttpGet("/api/relationships/{id}")]
        public async Task<RelationshipView> Get(int id)
        {
            return await _queryProcessor.ExecuteAsync(new GetRelationshipByIdQuery { Id = id });
        }
    }
}