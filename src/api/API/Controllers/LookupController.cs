using System.Collections.Generic;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class LookupController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public LookupController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        [Route("api/languages", Name = "GetLanguages")]
        public async Task<IEnumerable<KeyValuePair<string, int>>> GetLanguages()
        {
            return await _queryProcessor.ExecuteAsync(new GetLanguagesQuery());
        }

        [HttpGet]
        [Route("api/attributes", Name = "GetAttributes")]
        public async Task<IEnumerable<KeyValuePair<string, int>>> GetAttributes()
        {
            return await _queryProcessor.ExecuteAsync(new GetAttributesQuery());
        }

        [HttpGet]
        [Route("api/relationtypes", Name = "GetRelationTypes")]
        public async Task<IEnumerable<KeyValuePair<string, int>>> GetRelationTypes()
        {
            return await _queryProcessor.ExecuteAsync(new GetRelationshipTypesQuery());
        }
    }
}