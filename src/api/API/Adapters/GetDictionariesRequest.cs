using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
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
        private readonly IRenderResponseFromObject<DictionariesModel, DictionariesView> _dictionariesRenderer;
        private readonly IQueryProcessor _queryProcessor;

        public GetDictionariesRequestHandler(IQueryProcessor queryProcessor, IRenderResponseFromObject<DictionariesModel, DictionariesView> dictionariesRenderer)
        {
            _queryProcessor = queryProcessor;
            _dictionariesRenderer = dictionariesRenderer;
        }

        public override async Task<GetDictionariesRequest> HandleAsync(GetDictionariesRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var dictionaries = await _queryProcessor.ExecuteAsync(new GetDictionariesQuery(), cancellationToken);
            command.Result = _dictionariesRenderer.Render(dictionaries);
            return base.HandleAsync(command, cancellationToken);
        }
    }
}
