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
        private readonly IProvideDatabase _databaseProvider;

        public GetMeaningsByWordDetailIdQueryHandler(IProvideDatabase databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public override async Task<IEnumerable<MeaningModel>> ExecuteAsync(GetMeaningsByWordDetailIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var database = _databaseProvider.GetDatabaseForDictionary(query.DictionaryId))
            {
                var meanings = await database.Meaning
                                              .Where(t => t.WordDetailId == query.DetailId)
                                              .ToListAsync(cancellationToken);

                return meanings.Select(m => m.Map<Meaning, MeaningModel>());
            }
        }
    }
}