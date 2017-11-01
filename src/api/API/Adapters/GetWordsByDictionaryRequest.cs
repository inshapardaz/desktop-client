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
    public class GetWordsByDictionaryRequest : IRequest
    {
        public Guid Id { get; set; }

        public int DictionaryId { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public PageView<WordView> Result { get; set; }
    }

    public class GetWordsByDictionaryRequestHander : RequestHandlerAsync<GetWordsByDictionaryRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<PageRendererArgs<WordModel>, PageView<WordView>> _wordPageRenderer;

        public GetWordsByDictionaryRequestHander(IQueryProcessor queryProcessor, IRenderResponseFromObject<PageRendererArgs<WordModel>, PageView<WordView>> wordPageRenderer)
        {
            _queryProcessor = queryProcessor;
            _wordPageRenderer = wordPageRenderer;
        }

        public override async Task<GetWordsByDictionaryRequest> HandleAsync(GetWordsByDictionaryRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var query = await _queryProcessor.ExecuteAsync(new GetWordsByDictionaryIdQuery
            {
                DictionaryId = command.DictionaryId,
                PageNumber = command.PageNumber,
                PageSize = command.PageSize
            }, cancellationToken);
            var words = query;

            command.Result =  _wordPageRenderer.Render(new PageRendererArgs<WordModel>
            {
                Page = words,
                RouteArguments = new PagedRouteArgs { PageSize = command.PageSize, PageNumber = command.PageNumber },
                RouteName = "GetWords"
            });

            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
