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
    public class SearchWordsByTitleQueryHandler : QueryHandlerAsync<SearchWordsByTitleQuery, PageModel<WordModel>>
    {
        private readonly IProvideDatabase _databaseProvider;

        public SearchWordsByTitleQueryHandler(IProvideDatabase databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public override async Task<PageModel<WordModel>> ExecuteAsync(SearchWordsByTitleQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var database = _databaseProvider.GetDatabaseForDictionary(query.DictionaryId))
            {
                var wordIndices = database.Word.Where(w => w.Title.Contains(query.Title));

                var count = wordIndices.Count();
                var data = await wordIndices
                    .OrderBy(x => x.Title.Length)
                    .ThenBy(x => x.Title)
                    .Paginate(query.PageNumber, query.PageSize)
                    .ToListAsync(cancellationToken);

                return new PageModel<WordModel>
                {
                    PageNumber = query.PageNumber,
                    PageSize = query.PageSize,
                    TotalCount = count,
                    Data = data.Select(w => w.Map<Word, WordModel>())
                };
            }
        }
    }
}