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
    public class GetTranslationByIdRequest : IRequest
    {
        public Guid Id { get; set; }

        public int DictionaryId { get; set; }

        public int TranslationId { get; set; }

        public TranslationView Result { get; set; }
    }

    public class GetTranslationByIdRequestHandler : RequestHandlerAsync<GetTranslationByIdRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderTranslation _translationRenderer;

        public GetTranslationByIdRequestHandler(IQueryProcessor queryProcessor, IRenderTranslation translationRenderer)
        {
            _queryProcessor = queryProcessor;
            _translationRenderer = translationRenderer;
        }

        public override async Task<GetTranslationByIdRequest> HandleAsync(GetTranslationByIdRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var query = new GetTranslationByIdQuery
            {
                DictionaryId = command.DictionaryId, TranslationId  = command.TranslationId
            };
            var result = await _queryProcessor.ExecuteAsync(query, cancellationToken);
            command.Result = _translationRenderer.Render(result, command.DictionaryId);

            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
