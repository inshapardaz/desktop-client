﻿using System;
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
    public class GetRelationshipsByWordRequest : IRequest
    {
        public Guid Id { get; set; }

        public int WordId { get; set; }

        public int DictionaryId { get; set; }

        public IEnumerable<RelationshipView> Result { get; set; }
    }

    public class GetRelationshipsByWordRequestHandler : RequestHandlerAsync<GetRelationshipsByWordRequest>
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IRenderResponseFromObject<RelationshipModel, RelationshipView> _relationRenderer;

        public GetRelationshipsByWordRequestHandler(IQueryProcessor queryProcessor, IRenderResponseFromObject<RelationshipModel, RelationshipView> relationRenderer)
        {
            _queryProcessor = queryProcessor;
            _relationRenderer = relationRenderer;
        }

        public override async Task<GetRelationshipsByWordRequest> HandleAsync(GetRelationshipsByWordRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var query = new GetRelationshipsByWordIdQuery
            {
                DictionaryId = command.DictionaryId,
                WordId = command.WordId
            };
            var result = await _queryProcessor.ExecuteAsync(query, cancellationToken);
            command.Result = result.Select(r => _relationRenderer.Render(r));
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
