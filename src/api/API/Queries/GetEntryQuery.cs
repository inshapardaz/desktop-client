using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetEntryQuery : IQuery<EntryView>
    {
    }

    public class GetEntryQueryHandler : QueryHandlerAsync<GetEntryQuery, EntryView>
    {
        public override async Task<EntryView> ExecuteAsync(GetEntryQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<EntryView>("api");
        }
    }
}