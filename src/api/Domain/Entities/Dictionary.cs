using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Domain.Entities
{
    public class Dictionary
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public LanguageType Language { get; set; }

        public string FilePath { get; set; }

        public string UserId { get; set; }

        public long WordCount { get; set; }
    }
}
