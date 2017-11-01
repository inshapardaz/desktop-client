using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Adapters;
using Inshapardaz.Desktop.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAmACommandProcessor _commandProcessor;

        public HomeController(IAmACommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        [HttpGet("api", Name = "Entry")]
        [Produces(typeof(EntryView))]
        public async Task<IActionResult> Index()
        {
            var request = new GetEntryRequest();
            await _commandProcessor.SendAsync(request);
            return Ok(request.Result);
        }
    }
}