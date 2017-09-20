using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetRelationshipByIdQueryHandler : QueryHandlerAsync<GetRelationshipByIdQuery, RelationshipModel>
    {
        public override Task<RelationshipModel> ExecuteAsync(GetRelationshipByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}