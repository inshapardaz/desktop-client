using System.Collections.Generic;

namespace Inshapardaz.Desktop.Common.Models
{
    public class PageView<T>
    {
        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int CurrentPageIndex { get; set; }

        public IEnumerable<LinkView> Links { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}