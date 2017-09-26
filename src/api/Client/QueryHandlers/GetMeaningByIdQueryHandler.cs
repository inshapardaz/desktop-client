using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetMeaningByIdQueryHandler : QueryHandlerAsync<GetMeaningByIdQuery, MeaningModel>
    {
        public override async Task<MeaningModel> ExecuteAsync(GetMeaningByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<MeaningModel>($"api/meanings/{query.MeaningId}");
        }
    }
}