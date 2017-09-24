using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetDictionariesQueryHandler : QueryHandlerAsync<GetDictionariesQuery, DictionariesModel>
    {
        private readonly IProvideUserSettings _userSettings;

        public GetDictionariesQueryHandler(IProvideUserSettings userSettings)
        {
            _userSettings = userSettings;
        }
        public override async Task<DictionariesModel> ExecuteAsync(GetDictionariesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var dictionaryFiles = Directory.GetFiles(_userSettings.DictionariesFolder, "*.dat");
            var dictionaries = new List<DictionaryModel>();
            foreach (var dictionaryFile in dictionaryFiles)
            {
                dictionaries.Add(await GetDictionary(dictionaryFile, cancellationToken));
            }

            return new DictionariesModel{ Items = dictionaries};
        }

        private async Task<DictionaryModel> GetDictionary(string dbPath, CancellationToken cancellationToken)
        {
            using (var db = DatabaseConnection.Connect(dbPath))
            {
                var dictionary = await db.Dictionary.FirstOrDefaultAsync(cancellationToken);
                var result =  dictionary.Map<Data.Entities.Dictionary, DictionaryModel>();
                result.WordCount = await db.Word.CountAsync(cancellationToken);
                return result;
            }
        }
    }
}