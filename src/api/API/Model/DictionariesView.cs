﻿using System.Collections.Generic;

namespace Inshapardaz.Desktop.Api.Model
{
    public class DictionariesView
    {
        public IEnumerable<LinkView> Links { get; set; }

        public IEnumerable<DictionaryView> Items { get; set; }
    }
}