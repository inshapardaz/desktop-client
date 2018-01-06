using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;
using WordView = Inshapardaz.Desktop.Api.Model.WordView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class ThesaurusController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public ThesaurusController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet("api/alternates/{word}", Name = "GetWordAlternatives")]
        public Model.PageView<WordView> Get(string word, int pageNumber = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
            //return await _queryProcessor.ExecuteAsync(new GetAlternatesByWordIdQuery { Word = word, PageNumber = pageNumber, PageSize = pageSize });
        }
    }
}