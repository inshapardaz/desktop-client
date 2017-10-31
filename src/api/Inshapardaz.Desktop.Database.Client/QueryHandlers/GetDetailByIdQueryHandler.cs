using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Data;
using Inshapardaz.Data.Entities;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Database.Client.QueryHandlers
{
    public class GetDetailByIdQueryHandler : QueryHandlerAsync<GetDetailByIdQuery, WordDetailModel>
    {
        private readonly IProvideDatabase _databaseProvider;

        public GetDetailByIdQueryHandler(IProvideDatabase databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }
        public override async Task<WordDetailModel> ExecuteAsync(GetDetailByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var database = _databaseProvider.GetDatabaseForDictionary(query.DictionaryId))
            {
                var detail = await database.WordDetail.SingleOrDefaultAsync(d => d.Id == query.Id, cancellationToken);
                return detail.Map<WordDetail, WordDetailModel>();
            }
        }
    }
}