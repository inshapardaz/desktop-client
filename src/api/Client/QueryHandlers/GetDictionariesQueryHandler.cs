using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetDictionariesQueryHandler : QueryHandlerAsync<GetDictionariesQuery, DictionariesModel>
    {
        public override async Task<DictionariesModel> ExecuteAsync(GetDictionariesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<DictionariesModel>("/api/dictionaries");
        }
    }
}