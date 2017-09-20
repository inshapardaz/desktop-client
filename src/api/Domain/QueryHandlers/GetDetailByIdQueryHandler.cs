﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetDetailByIdQueryHandler : QueryHandlerAsync<GetDetailByIdQuery, WordDetailModel>
    {
        public override Task<WordDetailModel> ExecuteAsync(GetDetailByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}