using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetTranslationsByWordIdQueryHandler : QueryHandlerAsync<GetTranslationsByWordIdQuery, IEnumerable<TranslationModel>>
    {
        public override async Task<IEnumerable<TranslationModel>> ExecuteAsync(GetTranslationsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<TranslationModel>>($"api/words/{query.Id}/translations");
        }
    }
}