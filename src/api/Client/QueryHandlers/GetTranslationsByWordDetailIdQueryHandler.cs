using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetTranslationsByWordDetailIdQueryHandler : QueryHandlerAsync<GetTranslationsByWordDetailIdQuery, IEnumerable<TranslationModel>>
    {
        public override async Task<IEnumerable<TranslationModel>> ExecuteAsync(GetTranslationsByWordDetailIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<IEnumerable<TranslationModel>>($"api/detail/{query.DetailId}/translations");
        }
    }
}