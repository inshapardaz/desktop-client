using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Models;
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
        private readonly IRenderResponseFromObject<DictionaryModel, DictionaryView> _dictionaryRenderer;
        private readonly IQueryProcessor _queryProcessor;

        public GetDictionaryByIdRequestHandler(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public override async Task<GetDictionaryByIdRequest> HandleAsync(GetDictionaryByIdRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            command.Result = _dictionaryRenderer.Render(await _queryProcessor.ExecuteAsync(new GetDictionaryByIdQuery { Id = id}, cancellationToken));
            return base.HandleAsync(command, cancellationToken);
        }
    }
}
