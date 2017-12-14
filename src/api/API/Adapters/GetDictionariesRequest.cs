using System;
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
    public class GetDictionariesRequest : IRequest
    {
        public Guid Id { get; set; }

        public DictionariesView Result { get; set; }
    }

    public class GetDictionariesRequestHandler : RequestHandlerAsync<GetDictionariesRequest>
    {
        private readonly IRenderDictionaries _dictionariesRenderer;
        private readonly IQueryProcessor _queryProcessor;

        public GetDictionariesRequestHandler(IQueryProcessor queryProcessor, IRenderDictionaries dictionariesRenderer)
        {
            _queryProcessor = queryProcessor;
            _dictionariesRenderer = dictionariesRenderer;
        }

        public override async Task<GetDictionariesRequest> HandleAsync(GetDictionariesRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var dictionaries = await _queryProcessor.ExecuteAsync(new GetDictionariesQuery(), cancellationToken);
            var localDictionaries = await _queryProcessor.ExecuteAsync(new GetLocalDictionariesQuery(), cancellationToken);
            foreach (var dictionary in dictionaries.Items)
            {
                if (localDictionaries.Items.Any(d => d.Id == dictionary.Id))
                {
                    dictionary.IsOffline = true;
                }
            }

            command.Result = _dictionariesRenderer.Render(dictionaries);
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
