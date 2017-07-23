using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetWordByIdQuery : IQuery<WordView>
    {
        public int Id { get; set; }
    }

    public class GetWordByIdQueryHandler : QueryHandlerAsync<GetWordByIdQuery, WordView>
    {
        public override async Task<WordView> ExecuteAsync(GetWordByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<WordView>($"api/words/{query.Id}");
        }
    }
}