﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetRelationshipTypesQuery : IQuery<IEnumerable<KeyValuePair<string, int>>>
    {
    }

    public class GetRelationshipTypesQueryHandler : QueryHandlerAsync<GetRelationshipTypesQuery, IEnumerable<KeyValuePair<string, int>>>
    {
        public override async Task<IEnumerable<KeyValuePair<string, int>>> ExecuteAsync(GetRelationshipTypesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<KeyValuePair<string, int>>>("/api/attributes");
        }
    }
}