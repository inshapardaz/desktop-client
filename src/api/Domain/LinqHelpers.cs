using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inshapardaz.Desktop.Domain
{
    public static class LinqHelpers
    {
        public static IQueryable<T> Paginate<T>(
            this IOrderedQueryable<T> source,
            int pageNumber,
            int pageSize)
            where T : class
        {
            return source.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
        }
    }
}
