using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Brighter;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Adapters
{
    public class GetDictionaryByIdRequest : IRequest
    {
        public GetDictionaryByIdRequest(int id)
        {
            DictioaryId = id;
        }

        public Guid Id { get; set; }

        public int DictioaryId { get; set; }

        public DictionaryView Result { get; set; }
    }

    public class GetDictionaryByIdRequestHandler : RequestHandlerAsync<GetDictionaryByIdRequest>
    {
        private readonly IRenderDictionary _dictionaryRenderer;
        private readonly IQueryProcessor _queryProcessor;

        public GetDictionaryByIdRequestHandler(IQueryProcessor queryProcessor, IRenderDictionary dictionaryRenderer)
        {
            _queryProcessor = queryProcessor;
            _dictionaryRenderer = dictionaryRenderer;
        }

        public override async Task<GetDictionaryByIdRequest> HandleAsync(GetDictionaryByIdRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            command.Result = _dictionaryRenderer.Render(await _queryProcessor.ExecuteAsync(new GetDictionaryByIdQuery { Id = command.DictioaryId}, cancellationToken));
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
