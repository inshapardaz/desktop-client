using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetAlternatesByWordIdQueryHandler : QueryHandlerAsync<GetAlternatesByWordIdQuery, PageView<WordView>>
    {
        public override async Task<PageView<WordView>> ExecuteAsync(GetAlternatesByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}