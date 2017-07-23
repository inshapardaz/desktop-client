using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetDictionariesQuery : IQuery<DictionariesView>
    {
    }

    public class GetDictionariesQueryHandler : QueryHandlerAsync<GetDictionariesQuery, DictionariesView>
    {
        public override async Task<DictionariesView> ExecuteAsync(GetDictionariesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<DictionariesView>("/api/dictionaries");
        }
    }
}