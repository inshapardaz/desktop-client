using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetAttributesQueryHandler : QueryHandlerAsync<GetAttributesQuery, IEnumerable<KeyValuePair<string, int>>>
    {
        public override Task<IEnumerable<KeyValuePair<string, int>>> ExecuteAsync(GetAttributesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}