using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class SearchWordsByTitleQuery : IQuery<PageView<WordView>>
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string Title { get; set; }
    }

    public class SearchWordsByTitleQueryHandler : QueryHandlerAsync<SearchWordsByTitleQuery, PageView<WordView>>
    {
        public override async Task<PageView<WordView>> ExecuteAsync(SearchWordsByTitleQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<PageView<WordView>>($"api/words/search/{query.Title}?pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}