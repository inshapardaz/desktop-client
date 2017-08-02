﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetTranslationByIdQueryHandler : QueryHandlerAsync<GetTranslationByIdQuery, TranslationView>
    {
        public override Task<TranslationView> ExecuteAsync(GetTranslationByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}