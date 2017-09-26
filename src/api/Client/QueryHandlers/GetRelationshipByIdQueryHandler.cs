using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetRelationshipByIdQueryHandler : QueryHandlerAsync<GetRelationshipByIdQuery, RelationshipModel>
    {
        public override async Task<RelationshipModel> ExecuteAsync(GetRelationshipByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<RelationshipModel>($"/api/relationships/{query.RelationshipId}");
        }
    }
}