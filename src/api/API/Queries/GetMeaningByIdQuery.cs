using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetMeaningByIdQuery : IQuery<MeaningView>
    {
        public int Id { get; set; }
    }

    public class GetMeaningByIdQueryHandler : QueryHandlerAsync<GetMeaningByIdQuery, MeaningView>
    {
        public override async Task<MeaningView> ExecuteAsync(GetMeaningByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<MeaningView>($"api/meanings/{query.Id}");
        }
    }
}