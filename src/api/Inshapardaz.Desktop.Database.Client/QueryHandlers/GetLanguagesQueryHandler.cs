using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Database.Client.QueryHandlers
{
    public class GetLanguagesQueryHandler : QueryHandlerAsync<GetLanguagesQuery, IEnumerable<KeyValuePair<string, int>>>
    {
        public override Task<IEnumerable<KeyValuePair<string, int>>> ExecuteAsync(GetLanguagesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}