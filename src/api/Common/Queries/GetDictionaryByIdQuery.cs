﻿using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetDictionaryByIdQuery : IQuery<DictionaryModel>
    {
        public int Id { get; set; }
    }
}