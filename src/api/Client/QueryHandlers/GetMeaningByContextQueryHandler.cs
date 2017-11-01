using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetMeaningByContextQueryHandler : QueryHandlerAsync<GetMeaningByContextQuery, IEnumerable<MeaningModel>>
    {
        private readonly IApiClient _apiClient;

        public GetMeaningByContextQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<IEnumerable<MeaningModel>> ExecuteAsync(GetMeaningByContextQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<IEnumerable<MeaningModel>>($"api/dictionaries/{query.DictionaryId}/words/{query.WordId}/meanings/contexts/{query.Context}");
        }
    }
}