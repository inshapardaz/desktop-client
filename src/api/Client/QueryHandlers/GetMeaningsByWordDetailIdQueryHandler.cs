using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetMeaningsByWordDetailIdQueryHandler : QueryHandlerAsync<GetMeaningsByWordDetailIdQuery, IEnumerable<MeaningModel>>
    {
        private readonly IApiClient _apiClient;

        public GetMeaningsByWordDetailIdQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<IEnumerable<MeaningModel>> ExecuteAsync(GetMeaningsByWordDetailIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<IEnumerable<MeaningModel>>($"api/details/{query.DetailId}/meanings");
        }
    }
}