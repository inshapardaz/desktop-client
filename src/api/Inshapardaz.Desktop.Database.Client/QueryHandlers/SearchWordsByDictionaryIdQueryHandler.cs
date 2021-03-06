﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Data.Entities;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Database.Client.QueryHandlers
{
    public class SearchWordsByDictionaryIdQueryHandler : QueryHandlerAsync<SearchWordsByDictionaryIdQuery, PageModel<WordModel>>
    {
        private readonly IProvideDatabase _databaseProvider;

        public SearchWordsByDictionaryIdQueryHandler(IProvideDatabase databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public override async Task<PageModel<WordModel>> ExecuteAsync(SearchWordsByDictionaryIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var database = _databaseProvider.GetDatabaseForDictionary(query.DictionaryId))
            {
                var wordIndices = query.DictionaryId > 0
                    ? database.Word.Where(
                        x => x.DictionaryId == query.DictionaryId && x.Title.Contains(query.Query))
                    : database.Word.Where(x => x.Title.Contains(query.Query));

                var count = wordIndices.Count();
                var data = await wordIndices
                    .OrderBy(x => x.Title.Length)
                    .ThenBy(x => x.Title)
                    .Paginate(query.PageNumber, query.PageSize)
                    .ToListAsync(cancellationToken);

                return new PageModel<WordModel>
                {
                    CurrentPageIndex = query.PageNumber,
                    PageSize = query.PageSize,
                    PageCount = count,
                    Data = data.Select(w => w.Map<Word, WordModel>())
                };
            }
        }
    }
}