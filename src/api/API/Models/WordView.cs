using System;
using System.Collections.Generic;
using System.Text;

namespace Inshapardaz.Desktop.Api.Models
{
    public class WordView
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string TitleWithMovements { get; set; }

        public string Description { get; set; }

        public IEnumerable<LinkView> Links { get; set; }

        public string Pronunciation { get; set; }
    }
}