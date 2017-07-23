using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetWordByIdQueryHandler : QueryHandlerAsync<GetWordByIdQuery, WordView>
    {
        public override async Task<WordView> ExecuteAsync(GetWordByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}