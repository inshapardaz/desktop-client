using System.Collections.Generic;

namespace Inshapardaz.Desktop.Common.Models
{
    public class MeaningModel
    {
        public long Id { get; set; }

        public string Context { get; set; }

        public string Value { get; set; }

        public string Example { get; set; }

        public long WordId { get; set; }

        public IEnumerable<LinkModel> Links { get; set; }
    }
}