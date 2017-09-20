using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetDictionaryByIdQueryHandler : QueryHandlerAsync<GetDictionaryByIdQuery, DictionaryModel>
    {
        public override async Task<DictionaryModel> ExecuteAsync(GetDictionaryByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<DictionaryModel>($"/api/dictionaries/{query.Id}");
        }
    }
}