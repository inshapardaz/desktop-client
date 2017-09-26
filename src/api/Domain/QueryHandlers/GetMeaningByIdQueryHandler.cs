﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetMeaningByIdQueryHandler : QueryHandlerAsync<GetMeaningByIdQuery, MeaningModel>
    {
        public override Task<MeaningModel> ExecuteAsync(GetMeaningByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}