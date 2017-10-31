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
    public class GetTranslationByIdQueryHandler : QueryHandlerAsync<GetTranslationByIdQuery, TranslationModel>
    {
        private readonly IProvideDatabase _databaseProvider;

        public GetTranslationByIdQueryHandler(IProvideDatabase databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public override async Task<TranslationModel> ExecuteAsync(GetTranslationByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var database = _databaseProvider.GetDatabaseForDictionary(query.DictionaryId))
            {
                var translation = await database.Translation
                                                 .SingleOrDefaultAsync(t => t.Id == query.Id, cancellationToken);

                return translation.Map<Translation, TranslationModel>();
            }
        }
    }
}