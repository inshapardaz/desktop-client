using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetDetailByIdQuery : IQuery<WordDetailView>
    {
        public int Id { get; set; }
    }

    public class GetDetailByIdQueryHandler : QueryHandlerAsync<GetDetailByIdQuery, WordDetailView>
    {
        public override async Task<WordDetailView> ExecuteAsync(GetDetailByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<WordDetailView>($"/api/details/{query.Id}");
        }
    }
}