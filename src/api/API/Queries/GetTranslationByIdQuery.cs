using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetTranslationByIdQuery : IQuery<TranslationView>
    {
        public int Id { get; set; }
    }

    public class GetTranslationByIdQueryHandler : QueryHandlerAsync<GetTranslationByIdQuery, TranslationView>
    {
        public override async Task<TranslationView> ExecuteAsync(GetTranslationByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<TranslationView>($"api/translations/{query.Id}");
        }
    }
}