using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class SearchWordsByTitleQueryHandler : QueryHandlerAsync<SearchWordsByTitleQuery, PageModel<WordModel>>
    {
        public override async Task<PageModel<WordModel>> ExecuteAsync(SearchWordsByTitleQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<PageModel<WordModel>>($"api/words/search/{query.Title}?pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}