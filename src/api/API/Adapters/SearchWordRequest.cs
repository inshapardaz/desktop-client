using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Brighter;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Adapters
{
    public class SearchWordRequest : IRequest
    {
        public Guid Id { get; set; }

        public int DictionaryId { get; set; }

        public string Query { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public PageView<WordView> Result { get; set; }
    }

    public class SearchWordRequestHandler : RequestHandlerAsync<SearchWordRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<PageRendererArgs<WordModel>, PageView<WordView>> _wordPageRenderer;

        public SearchWordRequestHandler(IQueryProcessor queryProcessor, IRenderResponseFromObject<PageRendererArgs<WordModel>, PageView<WordView>> wordPageRenderer)
        {
            _queryProcessor = queryProcessor;
            _wordPageRenderer = wordPageRenderer;
        }

        public override async Task<SearchWordRequest> HandleAsync(SearchWordRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var words = await _queryProcessor.ExecuteAsync(new SearchWordsByDictionaryIdQuery
            {
                DictionaryId = command.DictionaryId,
                Query = command.Query,
                PageNumber = command.PageNumber,
                PageSize = command.PageSize
            }, cancellationToken);

            command.Result = _wordPageRenderer.Render(new PageRendererArgs<WordModel>
            {
                Page = words,
                RouteArguments = new PagedRouteArgs
                {
                    PageSize = command.PageSize,
                    PageNumber = command.PageNumber
                },
                RouteName = "SearchDictionary"
            });
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
