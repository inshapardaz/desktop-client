using System;
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
    public class GetTranslationsByWordDetailIdQueryHandler : QueryHandlerAsync<GetTranslationsByWordDetailIdQuery, IEnumerable<TranslationModel>>
    {
        private readonly IDictionaryDatabase _database;

        public GetTranslationsByWordDetailIdQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }

        public override async Task<IEnumerable<TranslationModel>> ExecuteAsync(GetTranslationsByWordDetailIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var translation = await _database.Translation.Where(t => t.WordDetailId == query.DetailId).ToListAsync(cancellationToken);
            return translation.Select(t => t.Map<Translation, TranslationModel>());
        }
    }
}