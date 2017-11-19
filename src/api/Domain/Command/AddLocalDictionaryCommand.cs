using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Domain.Command
{
    public class AddLocalDictionaryCommand : Command
    {
        public DictionaryModel Dictionary { get; set; }

        public string FilePath { get; set; }
    }
}
