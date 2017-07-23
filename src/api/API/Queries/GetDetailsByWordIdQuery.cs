﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetDetailsByWordIdQuery : IQuery<IEnumerable<WordDetailView>>
    {
        public int Id { get; set; }
    }

    public class GetDetailsByWordIdQueryHandler : QueryHandlerAsync<GetDetailsByWordIdQuery, IEnumerable<WordDetailView>>
    {
        public override async Task<IEnumerable<WordDetailView>> ExecuteAsync(GetDetailsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<WordDetailView>>($"/api/words/{query.Id}/details");
        }
    }
}