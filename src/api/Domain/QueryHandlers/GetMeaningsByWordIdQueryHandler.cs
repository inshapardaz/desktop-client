using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetMeaningsByWordIdQueryHandler : QueryHandlerAsync<GetMeaningsByWordIdQuery, IEnumerable<MeaningModel>>
    {
        public override Task<IEnumerable<MeaningModel>> ExecuteAsync(GetMeaningsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}