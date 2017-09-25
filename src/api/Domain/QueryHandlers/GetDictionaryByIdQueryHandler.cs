using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Data;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetDictionaryByIdQueryHandler : QueryHandlerAsync<GetDictionaryByIdQuery, DictionaryModel>
    {
        private readonly IDictionaryDatabase _database;

        public GetDictionaryByIdQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }
        public override async Task<DictionaryModel> ExecuteAsync(GetDictionaryByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var dictionary = await _database.Dictionary.FirstOrDefaultAsync(d => d.Id == query.Id, cancellationToken);
            var result = dictionary.Map<Data.Entities.Dictionary, DictionaryModel>();
            result.WordCount = await _database.Word.CountAsync(w => w.DictionaryId == dictionary.Id, cancellationToken);
            return result;
        }
    }
}