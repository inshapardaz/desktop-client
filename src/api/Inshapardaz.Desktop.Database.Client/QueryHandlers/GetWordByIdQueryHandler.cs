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
    public class GetWordByIdQueryHandler : QueryHandlerAsync<GetWordByIdQuery, WordModel>
    {
        private readonly IDictionaryDatabase _database;

        public GetWordByIdQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }
        public override async Task<WordModel> ExecuteAsync(GetWordByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var word = await _database.Word.SingleAsync(w => w.Id == query.Id, cancellationToken);
            return word.Map<Word, WordModel>();
        }
    }
}