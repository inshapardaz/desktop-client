using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetWordsStartingWithQuery : IQuery<PageView<WordView>>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        public string StartingWith { get; set; }
    }

    public class GetWordsStartingWithQueryHandler : QueryHandlerAsync<GetWordsStartingWithQuery, PageView<WordView>>
    {
        public override async Task<PageView<WordView>> ExecuteAsync(GetWordsStartingWithQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<PageView<WordView>>($"api/dictionaries/{query.Id}/words/startWith/{query.StartingWith}?pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}