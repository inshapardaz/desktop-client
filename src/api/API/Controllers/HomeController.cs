using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public HomeController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet, Route("api")]
        public async Task<EntryView> Index()
        {
            return await _queryProcessor.ExecuteAsync(new GetEntryQuery());
        }
    }
}