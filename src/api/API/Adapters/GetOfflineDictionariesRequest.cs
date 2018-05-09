using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Queries;
using Inshapardaz.Desktop.Domain.Queries;
using Paramore.Brighter;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Adapters
{
    public class GetOfflineDictionariesRequest : IRequest
    {
        public Guid Id { get; set; }

        public DictionariesView Result { get; set; }
    }

    public class GetOfflineDictionariesRequestHandler : RequestHandlerAsync<GetOfflineDictionariesRequest>
    {
        private readonly IRenderDictionaries _dictionariesRenderer;
        private readonly IQueryProcessor _queryProcessor;

        public GetOfflineDictionariesRequestHandler(IQueryProcessor queryProcessor, IRenderDictionaries dictionariesRenderer)
        {
            _queryProcessor = queryProcessor;
            _dictionariesRenderer = dictionariesRenderer;
        }

        public override async Task<GetOfflineDictionariesRequest> HandleAsync(GetOfflineDictionariesRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var dictionaries = await _queryProcessor.ExecuteAsync(new GetOfflineDictionariesQuery(), cancellationToken);
            var localDictionaries = await _queryProcessor.ExecuteAsync(new GetLocalDictionariesQuery(), cancellationToken);
            foreach (var dictionary in dictionaries.Items)
            {
                var isDownloading = await _queryProcessor.ExecuteAsync(new GetDictionaryDownloadJobQuery(dictionary.Id));
                dictionary.IsDownloading = isDownloading;

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
