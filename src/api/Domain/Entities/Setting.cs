using System.ComponentModel.DataAnnotations;

namespace Inshapardaz.Desktop.Domain.Entities
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        public string UserInterfaceLanguage { get; set; }
        
        public bool UseOffline { get; set; }

    }
}