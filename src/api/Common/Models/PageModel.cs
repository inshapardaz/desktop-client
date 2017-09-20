using System.Collections.Generic;

namespace Inshapardaz.Desktop.Common.Models
{
    public class PageModel<T>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}