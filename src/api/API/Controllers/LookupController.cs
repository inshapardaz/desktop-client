using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class LookupController : Controller
    {
        [HttpGet]
        [Route("api/languages", Name = "GetLanguages")]
        public async Task<IEnumerable<KeyValuePair<string, int>>> GetLanguages()
        {
            return await ApiClient.Get<IEnumerable<KeyValuePair<string, int>>>("/api/languages");
        }

        [HttpGet]
        [Route("api/attributes", Name = "GetAttributes")]
        public async Task<IEnumerable<KeyValuePair<string, int>>> GetAttributes()
        {
            return await ApiClient.Get<IEnumerable<KeyValuePair<string, int>>>("/api/attributes");
        }

        [HttpGet]
        [Route("api/relationtypes", Name = "GetRelationTypes")]
        public async Task<IEnumerable<KeyValuePair<string, int>>> GetRelationTypes()
        {
            return await ApiClient.Get<IEnumerable<KeyValuePair<string, int>>>("/api/attributes");
        }
    }
}