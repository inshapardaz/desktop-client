using System;
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
    public class GetWordsByDictionaryIdQueryHandler : QueryHandlerAsync<GetWordsByDictionaryIdQuery, PageModel<WordModel>>
    {
        private readonly IProvideUserSettings _userSettings;

        public GetWordsByDictionaryIdQueryHandler(IProvideUserSettings userSettings)
        {
            _userSettings = userSettings;
        }

        public override async Task<PageModel<WordModel>> ExecuteAsync(GetWordsByDictionaryIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var db = DatabaseConnection.ConnectToId(_userSettings, query.Id))
            {
                var data = await db.Word
                    .OrderBy(x => x.Title)
                    .Paginate(query.PageNumber, query.PageSize)
                    .ToListAsync(cancellationToken);
                return new PageModel<WordModel>
                {
                    Data = data.Select(w => w.Map<Data.Entities.Word, WordModel>()),
                    PageNumber = query.PageNumber,
                    PageSize = query.PageSize,
                    TotalCount = await db.Word.CountAsync(cancellationToken)
                };
            }
        }
    }
}