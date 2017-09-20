using Inshapardaz.Data.Entities;

namespace Inshapardaz.Desktop.Domain.Entities
{
    public class Dictionary
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public Languages Language { get; set; }

        public string FilePath { get; set; }

        public string UserId { get; set; }

        public long WordCount { get; set; }
    }
}
