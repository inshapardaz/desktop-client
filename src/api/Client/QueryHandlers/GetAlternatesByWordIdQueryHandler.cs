using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetAlternatesByWordIdQueryHandler : QueryHandlerAsync<GetAlternatesByWordIdQuery, PageModel<WordModel>>
    {
        private readonly IApiClient _apiClient;

        public GetAlternatesByWordIdQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<PageModel<WordModel>> ExecuteAsync(GetAlternatesByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<PageModel<WordModel>>($"api/alternates/{query.Word}?pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}