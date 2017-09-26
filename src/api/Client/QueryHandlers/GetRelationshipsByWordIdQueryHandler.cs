using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetRelationshipsByWordIdQueryHandler : QueryHandlerAsync<GetRelationshipsByWordIdQuery, IEnumerable<RelationshipModel>>
    {
        public override async Task<IEnumerable<RelationshipModel>> ExecuteAsync(GetRelationshipsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<RelationshipModel>>($"/api/words/{query.WordId}/relationships");
        }
    }
}