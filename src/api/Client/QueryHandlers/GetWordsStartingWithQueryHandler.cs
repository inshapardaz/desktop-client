using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetWordsStartingWithQueryHandler : QueryHandlerAsync<GetWordsStartingWithQuery, PageModel<WordModel>>
    {
        private readonly IApiClient _apiClient;

        public GetWordsStartingWithQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<PageModel<WordModel>> ExecuteAsync(GetWordsStartingWithQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<PageModel<WordModel>>($"api/dictionaries/{query.DictionaryId}/words/startWith/{query.StartingWith}?pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}