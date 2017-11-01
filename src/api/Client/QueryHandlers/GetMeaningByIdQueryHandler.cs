using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetMeaningByIdQueryHandler : QueryHandlerAsync<GetMeaningByIdQuery, MeaningModel>
    {
        private readonly IApiClient _apiClient;

        public GetMeaningByIdQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<MeaningModel> ExecuteAsync(GetMeaningByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<MeaningModel>($"api/dictionaries/{query.DictionaryId}/meanings/{query.MeaningId}");
        }
    }
}