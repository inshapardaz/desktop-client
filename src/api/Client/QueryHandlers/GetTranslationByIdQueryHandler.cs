using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetTranslationByIdQueryHandler : QueryHandlerAsync<GetTranslationByIdQuery, TranslationModel>
    {
        private readonly IApiClient _apiClient;

        public GetTranslationByIdQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<TranslationModel> ExecuteAsync(GetTranslationByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<TranslationModel>($"api/dictionaries/{query.DictionaryId}/translations/{query.TranslationId}");
        }
    }
}