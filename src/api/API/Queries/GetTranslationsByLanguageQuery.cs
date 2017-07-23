using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetTranslationsByLanguageQuery : IQuery<IEnumerable<TranslationView>>
    {
        public int Id { get; set; }
        public LanguageType Language { get; set; }
    }

    public class GetTranslationsByLanguageQueryHandler : QueryHandlerAsync<GetTranslationsByLanguageQuery, IEnumerable<TranslationView>>
    {
        public override async Task<IEnumerable<TranslationView>> ExecuteAsync(GetTranslationsByLanguageQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<TranslationView>>($"api/words/{query.Id}/translations/languages/{query.Language}");
        }
    }
}