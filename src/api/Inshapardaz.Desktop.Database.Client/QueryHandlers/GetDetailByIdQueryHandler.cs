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
        private readonly IDictionaryDatabase _database;

        public GetDetailByIdQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }
        public override async Task<WordDetailModel> ExecuteAsync(GetDetailByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var detail = await _database.WordDetail.SingleOrDefaultAsync(d => d.Id == query.Id, cancellationToken);
            return detail.Map<WordDetail, WordDetailModel>();
        }
    }
}