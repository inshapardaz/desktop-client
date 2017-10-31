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
    public class GetTranslationsByWordIdQueryHandler : QueryHandlerAsync<GetTranslationsByWordIdQuery, IEnumerable<TranslationModel>>
    {
        private readonly IProvideDatabase _databaseProvider;

        public GetTranslationsByWordIdQueryHandler(IProvideDatabase databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public override async Task<IEnumerable<TranslationModel>> ExecuteAsync(GetTranslationsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var database = _databaseProvider.GetDatabaseForDictionary(query.DictionaryId))
            {
                var translations = await database.Translation
                                                  .Where(t => t.WordDetail.WordInstanceId == query.Id)
                                                  .ToListAsync(cancellationToken);

                return translations.Select(t => t.Map<Translation, TranslationModel>());
            }
        }
    }
}