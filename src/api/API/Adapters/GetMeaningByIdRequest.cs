using System;
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
    public class GetMeaningByIdRequest : IRequest
    {
        public Guid Id { get; set; }

        public int MeaningId { get; set; }

        public int DictionaryId { get; set; }

        public MeaningView Result { get; set; }
    }

    public class GetMeaningByIdRequestHandler : RequestHandlerAsync<GetMeaningByIdRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<MeaningModel, MeaningView> _meaningRenderer;

        public GetMeaningByIdRequestHandler(IQueryProcessor queryProcessor, IRenderResponseFromObject<MeaningModel, MeaningView> meaningRenderer)
        {
            _queryProcessor = queryProcessor;
            _meaningRenderer = meaningRenderer;
        }

        public override async Task<GetMeaningByIdRequest> HandleAsync(GetMeaningByIdRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var query = new GetMeaningByIdQuery { DictionaryId = command.DictionaryId,  MeaningId = command.MeaningId };
            var result = await _queryProcessor.ExecuteAsync(query, cancellationToken);

            command.Result = _meaningRenderer.Render(result);

            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
