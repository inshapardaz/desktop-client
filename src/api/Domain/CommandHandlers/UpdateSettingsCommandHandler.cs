using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Domain.Command;
using Inshapardaz.Desktop.Domain.Contexts;
using Inshapardaz.Desktop.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Domain.CommandHandlers
{
    public class UpdateSettingsCommandHandler : RequestHandlerAsync<UpdateSettingsCommand>
    {
        private readonly IApplicationDatabase _applicationDatabase;

        public UpdateSettingsCommandHandler(IApplicationDatabase applicationDatabase)
        {
            _applicationDatabase = applicationDatabase;
        }

        public override async Task<UpdateSettingsCommand> HandleAsync(UpdateSettingsCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateApplicationConfiguratoion(command.Setting);
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

        private void UpdateApplicationConfiguratoion(Setting setting)
        {
            var configPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json");
            var configuration = JsonConvert.DeserializeObject<ApplicationSetting>(File.ReadAllText(configPath));
            configuration.UseOffline = setting.UseOffline;
            File.WriteAllText(configPath, JsonConvert.SerializeObject(configuration, Formatting.Indented));
        }

        private class ApplicationSetting
        {
            public string ApiAddress { get; set; }
            public string LocalApiAddress { get; set; }
            public string Datastore { get; set; }
            public bool UseOffline { get; set; }
        }
    }
}
