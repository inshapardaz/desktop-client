using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Database.Client.QueryHandlers
{
    public class GetDictionariesQueryHandler : QueryHandlerAsync<GetDictionariesQuery, DictionariesModel>
    {
        private readonly IQueryProcessor _queryProcessor;

        public GetDictionariesQueryHandler(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public override async Task<DictionariesModel> ExecuteAsync(GetDictionariesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _queryProcessor.ExecuteAsync(new GetLocalDictionariesQuery(), cancellationToken);
        }
    }
}