using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetAlternatesByWordIdQuery : IQuery<PageView<WordView>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Word { get; set; }
    }

    public class GetAlternatesByWordIdQueryHandler : QueryHandlerAsync<GetAlternatesByWordIdQuery, PageView<WordView>>
    {
        public override async Task<PageView<WordView>> ExecuteAsync(GetAlternatesByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<PageView<WordView>>($"api/alternates/{query.Word}?pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}