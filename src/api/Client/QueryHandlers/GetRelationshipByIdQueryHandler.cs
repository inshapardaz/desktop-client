using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetRelationshipByIdQueryHandler : QueryHandlerAsync<GetRelationshipByIdQuery, RelationshipModel>
    {
        private readonly IApiClient _apiClient;

        public GetRelationshipByIdQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<RelationshipModel> ExecuteAsync(GetRelationshipByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<RelationshipModel>($"/api/dictionaries/{query.DictionaryId}/relationships/{query.RelationshipId}");
        }
    }
}