using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class SearchWordsByTitleQueryHandler : QueryHandlerAsync<SearchWordsByTitleQuery, PageView<WordView>>
    {
        public override async Task<PageView<WordView>> ExecuteAsync(SearchWordsByTitleQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<PageView<WordView>>($"api/words/search/{query.Title}?pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}