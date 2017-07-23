using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetMeaningByContextQuery : IQuery<IEnumerable<MeaningView>>
    {
        public int Id { get; set; }
        public string Context { get; set; }
    }

    public class GetMeaningByContextQueryHandler : QueryHandlerAsync<GetMeaningByContextQuery, IEnumerable<MeaningView>>
    {
        public override async Task<IEnumerable<MeaningView>> ExecuteAsync(GetMeaningByContextQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<MeaningView>>($"api/words/{query.Id}/meanings/contexts/{query.Context}");
        }
    }
}