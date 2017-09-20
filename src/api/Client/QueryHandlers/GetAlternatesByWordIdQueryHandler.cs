using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetAlternatesByWordIdQueryHandler : QueryHandlerAsync<GetAlternatesByWordIdQuery, PageModel<WordModel>>
    {
        public override async Task<PageModel<WordModel>> ExecuteAsync(GetAlternatesByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<PageModel<WordModel>>($"api/alternates/{query.Word}?pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}