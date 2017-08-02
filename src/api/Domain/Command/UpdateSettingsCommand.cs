using Inshapardaz.Desktop.Domain.Entities;

namespace Inshapardaz.Desktop.Domain.Command
{
    public class UpdateSettingsCommand : Command
    {
        public Setting Setting { get; set; }   
    }
}