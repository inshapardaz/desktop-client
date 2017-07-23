using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class SearchWordsByDictionaryIdQuery : IQuery<PageView<WordView>>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        public string Query { get; set; }
    }

    public class SearchWordsByDictionaryIdQueryHandler : QueryHandlerAsync<SearchWordsByDictionaryIdQuery, PageView<WordView>>
    {
        public override async Task<PageView<WordView>> ExecuteAsync(SearchWordsByDictionaryIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<PageView<WordView>>($"api/dictionaries/{query.Id}/Search?query={query.Query}pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}