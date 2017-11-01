using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class GetTranslationsForLanguageRequest : IRequest
    {
        public Guid Id { get; set; }

        public int DictionaryId { get; set; }

        public int WordId { get; set; }

        public IEnumerable<TranslationView> Result { get; set; }

        public LanguageType Language { get; set; }
    }

    public class GetTranslationsForLanguageRequestHandler : RequestHandlerAsync<GetTranslationsForLanguageRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<TranslationModel, TranslationView> _translationRenderer;

        public GetTranslationsForLanguageRequestHandler(IQueryProcessor queryProcessor, IRenderResponseFromObject<TranslationModel, TranslationView> translationRenderer)
        {
            _queryProcessor = queryProcessor;
            _translationRenderer = translationRenderer;
        }

        public override async Task<GetTranslationsForLanguageRequest> HandleAsync(GetTranslationsForLanguageRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var query = new GetTranslationsByLanguageQuery
            {
                DictionaryId = command.DictionaryId,
                WordId = command.WordId,
                Language = command.Language
            };
            var result = await _queryProcessor.ExecuteAsync(query, cancellationToken);
            command.Result = result.Select(t => _translationRenderer.Render(t));

            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
