using System;
using System.Linq;
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
    public class GetWordsByDictionaryIdQueryHandler : QueryHandlerAsync<GetWordsByDictionaryIdQuery, PageModel<WordModel>>
    {
        private readonly IDictionaryDatabase _database;

        public GetWordsByDictionaryIdQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }

        public override async Task<PageModel<WordModel>> ExecuteAsync(GetWordsByDictionaryIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
                var data = await _database.Word
                    .Where(w => w.DictionaryId == query.Id)
                    .OrderBy(x => x.Title)
                    .Paginate(query.PageNumber, query.PageSize)
                    .ToListAsync(cancellationToken);
                return new PageModel<WordModel>
                {
                    Data = data.Select(w => w.Map<Data.Entities.Word, WordModel>()),
                    PageNumber = query.PageNumber,
                    PageSize = query.PageSize,
                    TotalCount = await _database.Word
                                                .CountAsync(w => w.DictionaryId == query.Id, cancellationToken)
                };
        }
    }
}