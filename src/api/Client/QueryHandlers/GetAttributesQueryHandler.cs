using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetAttributesQueryHandler : QueryHandlerAsync<GetAttributesQuery, IEnumerable<KeyValuePair<string, int>>>
    {
        private readonly IApiClient _apiClient;

        public GetAttributesQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<IEnumerable<KeyValuePair<string, int>>> ExecuteAsync(GetAttributesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<IEnumerable<KeyValuePair<string, int>>>("/api/attributes");
        }
    }
}