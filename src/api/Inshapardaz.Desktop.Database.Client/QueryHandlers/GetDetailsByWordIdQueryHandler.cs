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
    public class GetDetailsByWordIdQueryHandler : QueryHandlerAsync<GetDetailsByWordIdQuery, IEnumerable<WordDetailModel>>
    {
        private readonly IProvideDatabase _databaseProvider;

        public GetDetailsByWordIdQueryHandler(IProvideDatabase databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public override async Task<IEnumerable<WordDetailModel>> ExecuteAsync(GetDetailsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var database = _databaseProvider.GetDatabaseForDictionary(query.DictionaryId))
            {
                var data = await database.WordDetail.Where(d => d.WordInstanceId == query.Id)
                                          .ToListAsync(cancellationToken);
                return data.Select(d => d.Map<WordDetail, WordDetailModel>());
            }
        }
    }
}