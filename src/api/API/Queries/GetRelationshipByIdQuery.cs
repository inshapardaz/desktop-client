using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetRelationshipByIdQuery : IQuery<RelationshipView>
    {
        public int Id { get; set; }
    }

    public class GetRelationshipByIdQueryHandler : QueryHandlerAsync<GetRelationshipByIdQuery, RelationshipView>
    {
        public override async Task<RelationshipView> ExecuteAsync(GetRelationshipByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<RelationshipView>($"/api/relationships/{query.Id}");
        }
    }
}