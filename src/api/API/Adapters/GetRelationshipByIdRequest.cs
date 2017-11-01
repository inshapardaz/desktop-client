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
    public class GetRelationshipByIdRequest : IRequest
    {
        public Guid Id { get; set; }

        public int RelationshipId { get; set; }

        public int DictionaryId { get; set; }

        public RelationshipView Result { get; set; }
    }

    public class GetRelationshipByIdRequestHandler : RequestHandlerAsync<GetRelationshipByIdRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<RelationshipModel, RelationshipView> _relationRenderer;

        public GetRelationshipByIdRequestHandler(IQueryProcessor queryProcessor, IRenderResponseFromObject<RelationshipModel, RelationshipView> relationRenderer)
        {
            _queryProcessor = queryProcessor;
            _relationRenderer = relationRenderer;
        }

        public override async Task<GetRelationshipByIdRequest> HandleAsync(GetRelationshipByIdRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var query = new GetRelationshipByIdQuery
            {
                DictionaryId =  command.DictionaryId,
                RelationshipId = command.RelationshipId
            };
            var result = await _queryProcessor.ExecuteAsync(query, cancellationToken);
            command.Result = _relationRenderer.Render(result);
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
