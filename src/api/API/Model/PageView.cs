using System;
using System.Collections.Generic;

namespace Inshapardaz.Desktop.Api.Model
{
    public class PageView<T>
    {
        public PageView(int count, int pageSize, int currentPageIndex)
        {
            PageSize = pageSize;
            PageCount = Convert.ToInt32(Math.Ceiling((double)(count / PageSize)));
            CurrentPageIndex = currentPageIndex;

            if (PageCount == 0)
            {
                PageCount = 1;
            }
        }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int CurrentPageIndex { get; set; }

        public IEnumerable<LinkView> Links { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}