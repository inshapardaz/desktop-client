using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetDetailByIdQueryHandler : QueryHandlerAsync<GetDetailByIdQuery, WordDetailModel>
    {
        public override async Task<WordDetailModel> ExecuteAsync(GetDetailByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<WordDetailModel>($"/api/details/{query.Id}");
        }
    }
}