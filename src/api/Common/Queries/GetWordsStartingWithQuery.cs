﻿using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetWordsStartingWithQuery : IQuery<PageModel<WordModel>>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        public string StartingWith { get; set; }
    }
}