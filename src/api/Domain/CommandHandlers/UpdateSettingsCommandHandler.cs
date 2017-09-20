using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Domain.Command;
using Inshapardaz.Desktop.Domain.Contexts;
using Microsoft.Extensions.Configuration;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Domain.CommandHandlers
{
    public class UpdateSettingsCommandHandler : RequestHandlerAsync<UpdateSettingsCommand>
    {
        private readonly IApplicationDatabase _applicationDatabase;
        private readonly IConfigurationRoot _configuration;

        public UpdateSettingsCommandHandler(IApplicationDatabase applicationDatabase, IConfigurationRoot configuration)
        {
            _applicationDatabase = applicationDatabase;
            _configuration = configuration;
        }

        public override async Task<UpdateSettingsCommand> HandleAsync(UpdateSettingsCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            _configuration["useOffline"] = command.Setting.UseOffline.ToString();
            var setting = _applicationDatabase.Setting.FirstOrDefault();
            if (setting == null)
            {
                _applicationDatabase.Setting.Add(command.Setting);
                command.HasAdded = true;
            }
            else
            {
                setting.UseOffline = command.Setting.UseOffline;
                setting.UserInterfaceLanguage = command.Setting.UserInterfaceLanguage;
                command.HasAdded = false;
            }

            _applicationDatabase.SaveChanges();
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
