using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetEntryQueryHandler : QueryHandlerAsync<GetEntryQuery, EntryView>
    {
        public override async Task<EntryView> ExecuteAsync(GetEntryQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<EntryView>("api");
        }
    }
}