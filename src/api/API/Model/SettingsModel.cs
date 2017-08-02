using Inshapardaz.Desktop.Domain.Entities;

namespace Inshapardaz.Desktop.Api.Model
{
    public class SettingsModel
    {
        public string UserInterfaceLanguage { get; set; }

        public bool UseOfflineCollection { get; set; }
    }
}