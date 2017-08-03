using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Domain.Contexts;
using Inshapardaz.Desktop.Domain.Entities;
using Inshapardaz.Desktop.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetSettingsQueryHandler : QueryHandlerAsync<GetSettingsQuery, Setting>
    {
        private readonly IApplicationDatabase _applicationDatabase;

        public GetSettingsQueryHandler(IApplicationDatabase applicationDatabase)
        {
            _applicationDatabase = applicationDatabase;
        }

        public override async Task<Setting> ExecuteAsync(GetSettingsQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _applicationDatabase.Setting.FirstOrDefaultAsync(cancellationToken);
        }
    }
}