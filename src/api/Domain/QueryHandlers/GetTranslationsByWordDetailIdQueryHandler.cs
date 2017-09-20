using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetTranslationsByWordDetailIdQueryHandler : QueryHandlerAsync<GetTranslationsByWordDetailIdQuery, IEnumerable<TranslationModel>>
    {
        public override Task<IEnumerable<TranslationModel>> ExecuteAsync(GetTranslationsByWordDetailIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}