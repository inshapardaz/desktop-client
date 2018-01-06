using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Brighter;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Adapters
{
    public class GetEntryRequest : IRequest
    {
        public Guid Id { get; set; }

        public EntryView Result { get; set; }
    }

    public class GetEntryRequestHandler : RequestHandlerAsync<GetEntryRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderEntry _entryRenderer;

        public GetEntryRequestHandler(IQueryProcessor queryProcessor, IRenderEntry entryRenderer)
        {
            _queryProcessor = queryProcessor;
            _entryRenderer = entryRenderer;
        }

        public override async Task<GetEntryRequest> HandleAsync(GetEntryRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            command.Result = _entryRenderer.Render(await _queryProcessor.ExecuteAsync(new GetEntryQuery()));
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
