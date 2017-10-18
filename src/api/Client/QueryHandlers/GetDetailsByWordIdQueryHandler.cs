using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetDetailsByWordIdQueryHandler : QueryHandlerAsync<GetDetailsByWordIdQuery, IEnumerable<WordDetailModel>>
    {
        private readonly IApiClient _apiClient;

        public GetDetailsByWordIdQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<IEnumerable<WordDetailModel>> ExecuteAsync(GetDetailsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<IEnumerable<WordDetailModel>>($"/api/words/{query.Id}/details");
        }
    }
}