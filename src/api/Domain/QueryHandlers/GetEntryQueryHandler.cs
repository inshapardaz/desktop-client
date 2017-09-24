using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetEntryQueryHandler : QueryHandlerAsync<GetEntryQuery, EntryModel>
    {
        public override async Task<EntryModel> ExecuteAsync(GetEntryQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
           return await Task.FromResult<EntryModel>(null);
        }
    }
}