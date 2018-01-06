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
    public class GetMeaningForWordRequest : IRequest
    {
        public Guid Id { get; set; }

        public int DictionaryId { get; set; }

        public int WordId { get; set; }

        public IEnumerable<MeaningView> Result { get; set; }
    }

    public class GetMeaningForWordRequestHandler : RequestHandlerAsync<GetMeaningForWordRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderMeaning _meaningRenderer;

        public GetMeaningForWordRequestHandler(IQueryProcessor queryProcessor, IRenderMeaning meaningRenderer)
        {
            _queryProcessor = queryProcessor;
            _meaningRenderer = meaningRenderer;
        }

        public override async Task<GetMeaningForWordRequest> HandleAsync(GetMeaningForWordRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var query = new GetMeaningsByWordIdQuery { DictionaryId = command.DictionaryId, WordId = command.WordId };
            var result = await _queryProcessor.ExecuteAsync(query, cancellationToken);
            command.Result = result.Select(x => _meaningRenderer.Render(x, command.DictionaryId));
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
