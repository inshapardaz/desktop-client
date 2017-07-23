using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetMeaningsByWordIdQuery : IQuery<IEnumerable<MeaningView>>
    {
        public int Id { get; set; }
    }

    public class GetMeaningsByWordIdQueryHandler : QueryHandlerAsync<GetMeaningsByWordIdQuery, IEnumerable<MeaningView>>
    {
        public override async Task<IEnumerable<MeaningView>> ExecuteAsync(GetMeaningsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<MeaningView>>($"api/words/{query.Id}/meanings");
        }
    }
}