using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetRelationshipsByWordIdQueryHandler : QueryHandlerAsync<GetRelationshipsByWordIdQuery, IEnumerable<RelationshipView>>
    {
        public override async Task<IEnumerable<RelationshipView>> ExecuteAsync(GetRelationshipsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}