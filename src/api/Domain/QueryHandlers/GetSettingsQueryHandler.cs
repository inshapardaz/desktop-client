using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Domain.Entities;
using Inshapardaz.Desktop.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetSettingsQueryHandler : QueryHandlerAsync<GetSettingsQuery, Setting>
    {
        private readonly IDatabase _database;

        public GetSettingsQueryHandler(IDatabase database)
        {
            _database = database;
        }

        public override async Task<Setting> ExecuteAsync(GetSettingsQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _database.Setting.FirstOrDefaultAsync(cancellationToken);
        }
    }
}