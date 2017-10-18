using System.Collections.Generic;
using System.Linq;
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
    public class GetMeaningsByWordDetailIdQueryHandler : QueryHandlerAsync<GetMeaningsByWordDetailIdQuery, IEnumerable<MeaningModel>>
    {
        private readonly IDictionaryDatabase _database;

        public GetMeaningsByWordDetailIdQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }

        public override async Task<IEnumerable<MeaningModel>> ExecuteAsync(GetMeaningsByWordDetailIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var meanings = await _database.Meaning
                                          .Where(t => t.WordDetailId == query.DetailId)
                                          .ToListAsync(cancellationToken);

            return meanings.Select(m => m.Map<Meaning, MeaningModel>());
        }
    }
}