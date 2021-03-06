﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Database.Client.QueryHandlers
{
    public class GetWordsByDictionaryIdQueryHandler : QueryHandlerAsync<GetWordsByDictionaryIdQuery, PageModel<WordModel>>
    {
        private readonly IProvideDatabase _databaseProvider;

        public GetWordsByDictionaryIdQueryHandler(IProvideDatabase databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public override async Task<PageModel<WordModel>> ExecuteAsync(GetWordsByDictionaryIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var database = _databaseProvider.GetDatabaseForDictionary(query.DictionaryId))
            {
                var data = await database.Word
                                         .Where(w => w.DictionaryId == query.DictionaryId)
                                         .OrderBy(x => x.Title)
                                         .Paginate(query.PageNumber, query.PageSize)
                                         .ToListAsync(cancellationToken);
                return new PageModel<WordModel>
                {
                    Data = data.Select(w => w.Map<Data.Entities.Word, WordModel>()),
                    CurrentPageIndex = query.PageNumber,
                    PageSize = query.PageSize,
                    PageCount = await database.Word
                                               .CountAsync(w => w.DictionaryId == query.DictionaryId, cancellationToken)
                };
            }
        }
    }
}