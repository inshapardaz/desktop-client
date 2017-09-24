using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetDictionaryByIdQueryHandler : QueryHandlerAsync<GetDictionaryByIdQuery, DictionaryModel>
    {
        private readonly IProvideUserSettings _userSettings;

        public GetDictionaryByIdQueryHandler(IProvideUserSettings userSettings)
        {
            _userSettings = userSettings;
        }
        public override async Task<DictionaryModel> ExecuteAsync(GetDictionaryByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var db = DatabaseConnection.ConnectToId(_userSettings, query.Id))
            {
                var dictionary = await db.Dictionary.FirstOrDefaultAsync(cancellationToken);
                var result = dictionary.Map<Data.Entities.Dictionary, DictionaryModel>();
                result.WordCount = await db.Word.CountAsync(cancellationToken);
                return result;
            }
        }
    }
}