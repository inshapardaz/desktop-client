using System.Collections.Generic;

namespace Inshapardaz.Desktop.Common.Models
{
    public class PageModel<T>
    {
        public int CurrentPageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}