﻿using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.AspNetCore.Mvc;
using Paramore.Darker;
using WordView = Inshapardaz.Desktop.Api.Model.WordView;

namespace Inshapardaz.Desktop.Api.Controllers
{
    public class WordController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<WordModel, WordView> _wordRenderer;
        private readonly IRenderResponseFromObject<PageRendererArgs<WordModel>, PageView<WordView>> _wordPageRenderer;

        public WordController(IQueryProcessor queryProcessor,
                              IRenderResponseFromObject<WordModel, WordView> wordRenderer,
                              IRenderResponseFromObject<PageRendererArgs<WordModel>, PageView<WordView>> wordPageRenderer)
        {
            _queryProcessor = queryProcessor;
            _wordRenderer = wordRenderer;
            _wordPageRenderer = wordPageRenderer;
        }

        [Route("api/dictionaries/{id}/words", Name = "GetWords")]
        public async Task<Model.PageView<WordView>> Get(int id, int pageNumber = 1, int pageSize = 10)
        {
            var words = await _queryProcessor.ExecuteAsync(new GetWordsByDictionaryIdQuery { Id = id, PageNumber = pageNumber, PageSize = pageSize });

            return _wordPageRenderer.Render(new PageRendererArgs<WordModel>()
            {
                Page = words,
                RouteArguments = new PagedRouteArgs{ PageSize = pageSize, PageNumber = pageNumber},
                RouteName = "GetWords"
            });
        }

        [HttpGet("api/words/{id}", Name = "GetWordById")]
        public async Task<WordView> Get(int id)
        {
            return _wordRenderer.Render(await _queryProcessor.ExecuteAsync(new GetWordByIdQuery { Id = id }));
        }

        [HttpGet("api/dictionaries/{id}/Search", Name = "SearchDictionary")]
        public async Task<Model.PageView<WordView>> SearchDictionary(int id, string query, int pageNumber = 1, int pageSize = 10)
        {
            var words = await _queryProcessor.ExecuteAsync(new SearchWordsByDictionaryIdQuery { Id = id, Query = query, PageNumber = pageNumber, PageSize = pageSize });
            return _wordPageRenderer.Render(new PageRendererArgs<WordModel>()
            {
                Page = words,
                RouteArguments = new PagedRouteArgs { PageSize = pageSize, PageNumber = pageNumber },
                RouteName = "SearchDictionary"
            });
        }

        [HttpGet("api/dictionaries/{id}/words/startWith/{startingWith}", Name = "GetWordsListStartWith")]
        public async Task<Model.PageView<WordView>> StartsWith(int id, string startingWith, int pageNumber = 1, int pageSize = 10)
        {
            var words = await _queryProcessor.ExecuteAsync(new GetWordsStartingWithQuery { Id = id, StartingWith = startingWith, PageNumber = pageNumber, PageSize = pageSize });
            return _wordPageRenderer.Render(new PageRendererArgs<WordModel>()
            {
                Page = words,
                RouteArguments = new PagedRouteArgs { PageSize = pageSize, PageNumber = pageNumber },
                RouteName = "GetWordsListStartWith"
            });
        }

        [HttpGet("api/words/search/{title}", Name = "WordSearch")]
        public async Task<Model.PageView<WordView>> Search(string title, int pageNumber = 1, int pageSize = 10)
        {
            var words = await _queryProcessor.ExecuteAsync(new SearchWordsByTitleQuery { Title = title, PageNumber = pageNumber, PageSize = pageSize });
            return _wordPageRenderer.Render(new PageRendererArgs<WordModel>()
            {
                Page = words,
                RouteArguments = new PagedRouteArgs { PageSize = pageSize, PageNumber = pageNumber },
                RouteName = "WordSearch"
            });
        }
    }
}