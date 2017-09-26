using System;
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
    public class GetMeaningByIdQueryHandler : QueryHandlerAsync<GetMeaningByIdQuery, MeaningModel>
    {
        private readonly IDictionaryDatabase _database;

        public GetMeaningByIdQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }


        public override async Task<MeaningModel> ExecuteAsync(GetMeaningByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return (await _database.Meaning.SingleOrDefaultAsync(m => m.Id == query.MeaningId, cancellationToken)).Map<Meaning, MeaningModel>();
        }
    }
}