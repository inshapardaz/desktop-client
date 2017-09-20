using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetMeaningsByWordIdQueryHandler : QueryHandlerAsync<GetMeaningsByWordIdQuery, IEnumerable<MeaningModel>>
    {
        public override async Task<IEnumerable<MeaningModel>> ExecuteAsync(GetMeaningsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<MeaningModel>>($"api/words/{query.Id}/meanings");
        }
    }
}