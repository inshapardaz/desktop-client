using System.Collections.Generic;

namespace Inshapardaz.Desktop.Api.Model
{
    public class MeaningView
    {
        public long Id { get; set; }

        public string Context { get; set; }

        public string Value { get; set; }

        public string Example { get; set; }

        public long WordDetailId { get; set; }

        public IEnumerable<LinkView> Links { get; set; }
    }
}