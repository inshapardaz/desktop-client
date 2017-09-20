using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetMeaningByContextQueryHandler : QueryHandlerAsync<GetMeaningByContextQuery, IEnumerable<MeaningModel>>
    {
        public override async Task<IEnumerable<MeaningModel>> ExecuteAsync(GetMeaningByContextQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<MeaningModel>>($"api/words/{query.Id}/meanings/contexts/{query.Context}");
        }
    }
}