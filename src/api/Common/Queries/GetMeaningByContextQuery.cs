﻿using System.Collections.Generic;
using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetMeaningByContextQuery : IQuery<IEnumerable<MeaningModel>>
    {
        public int WordId { get; set; }
        public string Context { get; set; }

        public int DictionaryId { get; set; }
    }
}