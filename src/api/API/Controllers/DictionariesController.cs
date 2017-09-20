using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;
using DictionariesView = Inshapardaz.Desktop.Api.Model.DictionariesView;
using DictionaryView = Inshapardaz.Desktop.Api.Model.DictionaryView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class DictionariesController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<DictionariesModel, DictionariesView> _dictionariesRenderer;
        private readonly IRenderResponseFromObject<DictionaryModel, DictionaryView> _dictionaryRenderer;

        public DictionariesController(IQueryProcessor queryProcessor,
                                      IRenderResponseFromObject<DictionariesModel, DictionariesView> dictionariesRenderer,
                                      IRenderResponseFromObject<DictionaryModel, DictionaryView> dictionaryRenderer)
        {
            _queryProcessor = queryProcessor;
            _dictionariesRenderer = dictionariesRenderer;
            _dictionaryRenderer = dictionaryRenderer;
        }

        [HttpGet("/api/dictionaries", Name = "GetDictionaries")]
        public async Task<DictionariesView> Get()
        {
            return  _dictionariesRenderer.Render(await _queryProcessor.ExecuteAsync(new GetDictionariesQuery()));
        }

        [HttpGet("/api/dictionaries/{id}", Name = "GetDictionaryById")]
        public async Task<DictionaryView> Get(int id)
        {
            return _dictionaryRenderer.Render(await _queryProcessor.ExecuteAsync(new GetDictionaryByIdQuery { Id = id }));
        }
    }
}