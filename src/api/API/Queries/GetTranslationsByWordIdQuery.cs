using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetTranslationsByWordIdQuery : IQuery<IEnumerable<TranslationView>>
    {
        public int Id { get; set; }
    }

    public class GetTranslationsByWordIdQueryHandler : QueryHandlerAsync<GetTranslationsByWordIdQuery, IEnumerable<TranslationView>>
    {
        public override async Task<IEnumerable<TranslationView>> ExecuteAsync(GetTranslationsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<TranslationView>>($"api/words/{query.Id}/translations");
        }
    }
}