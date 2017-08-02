using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetWordsStartingWithQueryHandler : QueryHandlerAsync<GetWordsStartingWithQuery, PageView<WordView>>
    {
        public override Task<PageView<WordView>> ExecuteAsync(GetWordsStartingWithQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}