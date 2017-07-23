using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetRelationshipsByWordIdQuery : IQuery<IEnumerable<RelationshipView>>
    {
        public int Id { get; set; }
    }

    public class GetRelationshipsByWordIdQueryHandler : QueryHandlerAsync<GetRelationshipsByWordIdQuery, IEnumerable<RelationshipView>>
    {
        public override async Task<IEnumerable<RelationshipView>> ExecuteAsync(GetRelationshipsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<RelationshipView>>($"/api/words/{query.Id}/relationships");
        }
    }
}