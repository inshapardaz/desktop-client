using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetTranslationByIdQueryHandler : QueryHandlerAsync<GetTranslationByIdQuery, TranslationModel>
    {
        public override async Task<TranslationModel> ExecuteAsync(GetTranslationByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<TranslationModel>($"api/translations/{query.Id}");
        }
    }
}