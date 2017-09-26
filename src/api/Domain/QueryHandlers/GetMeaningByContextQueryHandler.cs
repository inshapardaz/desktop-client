﻿using System;
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

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetMeaningByContextQueryHandler : QueryHandlerAsync<GetMeaningByContextQuery, IEnumerable<MeaningModel>>
    {
        private readonly IDictionaryDatabase _database;

        public GetMeaningByContextQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }

        public override async Task<IEnumerable<MeaningModel>> ExecuteAsync(GetMeaningByContextQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var meanings = await _database.Meaning
                                          .Where(t => t.WordDetail.WordInstanceId == query.WordId && t.Context == query.Context)
                                          .ToListAsync(cancellationToken);

            return meanings.Select(m => m.Map<Meaning, MeaningModel>());
        }
    }
}