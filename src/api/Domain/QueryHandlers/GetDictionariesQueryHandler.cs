using System;
using System.Collections.Generic;
using System.IO;
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

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetDictionariesQueryHandler : QueryHandlerAsync<GetDictionariesQuery, DictionariesModel>
    {
        private readonly IDictionaryDatabase _database;

        public GetDictionariesQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }

        public override async Task<DictionariesModel> ExecuteAsync(GetDictionariesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var dictionaries = new List<DictionaryModel>();
            foreach (var dictionary in _database.Dictionary)
            {
                dictionaries.Add(await GetDictionary(dictionary, cancellationToken));
            }

            return new DictionariesModel{ Items = dictionaries};
        }

        private async Task<DictionaryModel> GetDictionary(Dictionary dictionary, CancellationToken cancellationToken)
        {
            var result =  dictionary.Map<Dictionary, DictionaryModel>();
            result.WordCount = await _database.Word.CountAsync(w => w.DictionaryId == dictionary.Id, cancellationToken);
            return result;
        }
    }
}