﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Data.Entities;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Database.Client.QueryHandlers
{
    public class GetMeaningsByWordIdQueryHandler : QueryHandlerAsync<GetMeaningsByWordIdQuery, IEnumerable<MeaningModel>>
    {
        private readonly IProvideDatabase _databaseProvider;

        public GetMeaningsByWordIdQueryHandler(IProvideDatabase databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public override async Task<IEnumerable<MeaningModel>> ExecuteAsync(GetMeaningsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var database = _databaseProvider.GetDatabaseForDictionary(query.DictionaryId))
            {
                var meanings = await database.Meaning
                                              .Where(t => t.WordId == query.WordId)
                                              .ToListAsync(cancellationToken);

                return meanings.Select(m => m.Map<Meaning, MeaningModel>());
            }
        }
    }
}