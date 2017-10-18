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
    public class GetTranslationsByLanguageQueryHandler : QueryHandlerAsync<GetTranslationsByLanguageQuery, IEnumerable<TranslationModel>>
    {
        private readonly IDictionaryDatabase _database;

        public GetTranslationsByLanguageQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }

        public override async Task<IEnumerable<TranslationModel>> ExecuteAsync(GetTranslationsByLanguageQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var translations = await _database.Translation
                                  .Where(t => t.WordDetail.WordInstanceId == query.Id && (int)t.Language == (int) query.Language)
                                  .ToListAsync(cancellationToken);
            return translations.Select(t => t.Map<Translation, TranslationModel>());
        }
    }
}