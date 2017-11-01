using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetTranslationsByLanguageQueryHandler : QueryHandlerAsync<GetTranslationsByLanguageQuery, IEnumerable<TranslationModel>>
    {
        private readonly IApiClient _apiClient;

        public GetTranslationsByLanguageQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<IEnumerable<TranslationModel>> ExecuteAsync(GetTranslationsByLanguageQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<IEnumerable<TranslationModel>>($"api/dictionaries/{query.DictionaryId}/words/{query.WordId}/translations/languages/{query.Language}");
        }
    }
}