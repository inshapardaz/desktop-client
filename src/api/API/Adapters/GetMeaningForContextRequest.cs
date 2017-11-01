using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GetMeaningForContextRequest : IRequest
    {
        public Guid Id { get; set; }

        public int WordId { get; set; }

        public string Context { get; set; }

        public int DictionaryId { get; set; }

        public IEnumerable<MeaningView> Result { get; set; }
    }

    public class GetMeaningForContextRequestHandler : RequestHandlerAsync<GetMeaningForContextRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<MeaningModel, MeaningView> _meaningRenderer;

        public GetMeaningForContextRequestHandler(IQueryProcessor queryProcessor, IRenderResponseFromObject<MeaningModel, MeaningView> meaningRenderer)
        {
            _queryProcessor = queryProcessor;
            _meaningRenderer = meaningRenderer;
        }

        public override async Task<GetMeaningForContextRequest> HandleAsync(GetMeaningForContextRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var query = new GetMeaningByContextQuery { DictionaryId = command.DictionaryId, WordId = command.WordId, Context = command.Context };
            var result = await _queryProcessor.ExecuteAsync(query, cancellationToken);
            command.Result = result.Select(x => _meaningRenderer.Render(x));
            return await base.HandleAsync(command, cancellationToken);
        }
    }

}
