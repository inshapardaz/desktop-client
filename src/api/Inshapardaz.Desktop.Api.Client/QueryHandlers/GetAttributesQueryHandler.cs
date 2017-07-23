using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetAttributesQueryHandler : QueryHandlerAsync<GetAttributesQuery, IEnumerable<KeyValuePair<string, int>>>
    {
        public override async Task<IEnumerable<KeyValuePair<string, int>>> ExecuteAsync(GetAttributesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<KeyValuePair<string, int>>>("/api/attributes");
        }
    }
}