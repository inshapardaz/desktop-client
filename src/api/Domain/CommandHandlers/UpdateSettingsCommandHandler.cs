using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Domain.Command;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Domain.CommandHandlers
{
    public class UpdateSettingsCommandHandler : RequestHandlerAsync<UpdateSettingsCommand>
    {
        private readonly IDatabase _database;

        public UpdateSettingsCommandHandler(IDatabase database)
        {
            _database = database;
        }

        public override async Task<UpdateSettingsCommand> HandleAsync(UpdateSettingsCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var setting = _database.Setting.FirstOrDefault();
            if (setting == null)
            {
                _database.Setting.Add(command.Setting);
                command.HasAdded = true;
            }
            else
            {
                setting.UseOffline = command.Setting.UseOffline;
                setting.UserInterfaceLanguage = command.Setting.UserInterfaceLanguage;
                command.HasAdded = false;
            }

            _database.SaveChanges();
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
