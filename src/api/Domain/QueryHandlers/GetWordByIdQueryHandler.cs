using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetWordByIdQueryHandler : QueryHandlerAsync<GetWordByIdQuery, WordModel>
    {
        public override async Task<WordModel> ExecuteAsync(GetWordByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var connectionString = new SqliteConnectionStringBuilder {DataSource = "1.dat"};
            var optionsBuilder = new DbContextOptionsBuilder<Data.DictionaryDatabase>();
            optionsBuilder.UseSqlite(connectionString.ConnectionString);
            using (var database = new Data.DictionaryDatabase(optionsBuilder.Options))
            {
                var word = await database.Word.SingleAsync(w => w.Id == query.Id, cancellationToken);
                return new WordModel
                {
                    Id = word.Id,
                    Title = word.Title,
                    TitleWithMovements = word.TitleWithMovements
                };
            }
        }
    }
}