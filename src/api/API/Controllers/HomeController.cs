using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;
using EntryView = Inshapardaz.Desktop.Api.Model.EntryView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<EntryModel, EntryView> _entryRenderer;

        public HomeController(IQueryProcessor queryProcessor, IRenderResponseFromObject<EntryModel, EntryView> entryRenderer)
        {
            _queryProcessor = queryProcessor;
            _entryRenderer = entryRenderer;
        }

        [HttpGet("api", Name = "Entry")]
        public async Task<EntryView> Index()
        {
            return _entryRenderer.Render(await _queryProcessor.ExecuteAsync(new GetEntryQuery()));
        }
    }
}