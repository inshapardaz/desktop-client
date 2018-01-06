using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Brighter;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Adapters
{
    public class GetTranslationsForWordRequest : IRequest
    {
        public Guid Id { get; set; }

        public int DictionaryId { get; set; }

        public int WordId { get; set; }

        public IEnumerable<TranslationView> Result { get; set; }
    }

    public class GetTranslationsForWordRequestHandler : RequestHandlerAsync<GetTranslationsForWordRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderTranslation _translationRenderer;

        public GetTranslationsForWordRequestHandler(IQueryProcessor queryProcessor, IRenderTranslation translationRenderer)
        {
            _queryProcessor = queryProcessor;
            _translationRenderer = translationRenderer;
        }

        public override async Task<GetTranslationsForWordRequest> HandleAsync(GetTranslationsForWordRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var query = new GetTranslationsByWordIdQuery { DictionaryId = command.DictionaryId, WordId = command.WordId };
            var result = await _queryProcessor.ExecuteAsync(query, cancellationToken);
            command.Result = result.Select(t => _translationRenderer.Render(t, command.DictionaryId));

            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
