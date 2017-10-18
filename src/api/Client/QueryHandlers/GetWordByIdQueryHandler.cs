using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetWordByIdQueryHandler : QueryHandlerAsync<GetWordByIdQuery, WordModel>
    {
        private readonly IApiClient _apiClient;

        public GetWordByIdQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<WordModel> ExecuteAsync(GetWordByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<WordModel>($"api/words/{query.Id}");
        }
    }
}