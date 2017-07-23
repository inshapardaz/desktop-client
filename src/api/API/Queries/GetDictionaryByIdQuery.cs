using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetDictionaryByIdQuery : IQuery<DictionaryView>
    {
        public int Id { get; set; }
    }

    public class GetDictionaryByIdQueryHandler : QueryHandlerAsync<GetDictionaryByIdQuery, DictionaryView>
    {
        public override async Task<DictionaryView> ExecuteAsync(GetDictionaryByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<DictionaryView>($"/api/dictionaries/{query.Id}");
        }
    }
}