using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Database.Client.QueryHandlers
{
    public class GetDictionaryByIdQueryHandler : QueryHandlerAsync<GetDictionaryByIdQuery, DictionaryModel>
    {
        private readonly IProvideDatabase _databaseProvider;

        public GetDictionaryByIdQueryHandler(IProvideDatabase databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }
        public override async Task<DictionaryModel> ExecuteAsync(GetDictionaryByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var database = _databaseProvider.GetDatabaseForDictionary(query.Id))
            {
                var dictionary = await database.Dictionary.FirstOrDefaultAsync(d => d.Id == query.Id, cancellationToken);
                var result = dictionary.Map<Data.Entities.Dictionary, DictionaryModel>();
                result.WordCount = await database.Word.CountAsync(w => w.DictionaryId == dictionary.Id, cancellationToken);
                return result;
            }
        }
    }
}