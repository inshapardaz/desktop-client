using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetTranslationsByLanguageQueryHandler : QueryHandlerAsync<GetTranslationsByLanguageQuery, IEnumerable<TranslationView>>
    {
        public override async Task<IEnumerable<TranslationView>> ExecuteAsync(GetTranslationsByLanguageQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<TranslationView>>($"api/words/{query.Id}/translations/languages/{query.Language}");
        }
    }
}