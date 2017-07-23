﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetRelationshipTypesQueryHandler : QueryHandlerAsync<GetRelationshipTypesQuery, IEnumerable<KeyValuePair<string, int>>>
    {
        public override async Task<IEnumerable<KeyValuePair<string, int>>> ExecuteAsync(GetRelationshipTypesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}