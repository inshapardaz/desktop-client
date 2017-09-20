using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class SearchWordsByDictionaryIdQueryHandler : QueryHandlerAsync<SearchWordsByDictionaryIdQuery, PageModel<WordModel>>
    {
        public override async Task<PageModel<WordModel>> ExecuteAsync(SearchWordsByDictionaryIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<PageModel<WordModel>>($"api/dictionaries/{query.Id}/Search?query={query.Query}pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}