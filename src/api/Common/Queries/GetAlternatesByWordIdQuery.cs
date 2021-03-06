﻿using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetAlternatesByWordIdQuery : IQuery<PageModel<WordModel>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Word { get; set; }
    }
}