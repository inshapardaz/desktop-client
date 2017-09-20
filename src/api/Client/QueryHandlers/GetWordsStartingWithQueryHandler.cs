using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetWordsStartingWithQueryHandler : QueryHandlerAsync<GetWordsStartingWithQuery, PageModel<WordModel>>
    {
        public override async Task<PageModel<WordModel>> ExecuteAsync(GetWordsStartingWithQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<PageModel<WordModel>>($"api/dictionaries/{query.Id}/words/startWith/{query.StartingWith}?pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}